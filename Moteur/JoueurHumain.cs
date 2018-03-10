using IAEchecs.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAEchecs.Moteur
{
    class JoueurHumain : Joueur
    {
        TaskCompletionSource<Mouvement> aJoue = null;
        private Coords debutMouvement;

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
            debutMouvement = null;
            aJoue = new TaskCompletionSource<Mouvement>();
            var valide = false;
            Mouvement mouv = null;
            while (!valide)
            {
                mouv = await aJoue.Task;
                Console.WriteLine("mouv choisi");
                valide = mouv.EstValide(plateau, EstBlanc);
            }
            
            deselectionnerToutesLesCases();
            deselectionnerToutesLesCases = null;
            return mouv;
        }

        public void OnCaseSelectionnee(Object sender, SelectionCaseEventArg e)
        {
            if (e.Handled) return;
            Console.WriteLine("Case cliquee");
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
