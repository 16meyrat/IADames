using IADames.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IADames.Moteur
{
    class JoueurHumain : Joueur
    {
        TaskCompletionSource<Mouvement> aJoue = null;
        private Coords debutMouvement;
        private Plateau plateauTMP;
        private bool aLeTrait = false;

        private Action deselectionnerToutesLesCases;

        public JoueurHumain(bool estBlanc, MainWindowForm echequierUI) : base(estBlanc)
        {
            foreach(var cellule in echequierUI.CasesEchec)
            {
                cellule.CaseCliqueeEvent += OnCaseSelectionnee;
            }
            
        }

        public override async Task<Mouvement> JouerAsync(Plateau plateau)
        {
            aLeTrait = true;
            plateauTMP = plateau;
            var valide = false;
            Mouvement mouv = null;
            while (!valide)
            {
                debutMouvement = null;
                aJoue = new TaskCompletionSource<Mouvement>();

                mouv = await aJoue.Task;

                Console.WriteLine("mouv choisi");
                valide = mouv.EstValide(plateau, EstBlanc);

                if (!valide)
                {
                    deselectionnerToutesLesCases();
                    deselectionnerToutesLesCases = null;  
                    Console.WriteLine("Mouvement invalide");
                }
               
            }

            deselectionnerToutesLesCases();
            deselectionnerToutesLesCases = null;
            aLeTrait = false;
            return mouv;
        }

        public void OnCaseSelectionnee(Object sender, SelectionCaseEventArg e)
        {
            if (e.Handled && !aLeTrait) return;
            deselectionnerToutesLesCases += e.Deselectionner;

            if (e.Selectionnee)
            {
                if(debutMouvement == null)
                {
                    debutMouvement = new Coords((sbyte)e.X, (sbyte)e.Y);
                    Console.WriteLine("debut mouv");
                }
                else
                {
                    Console.WriteLine("fin mouv "+EstBlanc);
                    aJoue.TrySetResult(new Mouvement(debutMouvement, new Coords((sbyte)e.X, (sbyte)e.Y)));
                }
            }
            else
            {
                debutMouvement = null;
            }

            e.Handled = true;
        }
    }
}
