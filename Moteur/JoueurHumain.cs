using IADames.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IADames.Moteur
{
    class JoueurHumain : Joueur
    {
        TaskCompletionSource<Mouvement> aJoue = null;
        private Mouvement mouvement;
        private Plateau plateauTMP;
        private bool aLeTrait = false;
        private int nbDePrisesTmp = 0;

        private Action deselectionnerToutesLesCases;

        public JoueurHumain(bool estBlanc, MainWindowForm echequierUI) : base(estBlanc)
        {
            foreach(var cellule in echequierUI.CasesDames)
            {
                cellule.CaseCliqueeEvent += OnCaseSelectionnee;
            }
            
        }

        public override Mouvement Jouer(Plateau plateau, CancellationToken annulation)
        {
            aLeTrait = true;
            plateauTMP = plateau;
            var valide = false;
            mouvement = null;
            Mouvement mouvFinal = null;
            
            while (!valide)
            {
                mouvement = null;
                annulation.Register(() => aJoue.TrySetCanceled(annulation), true);
                aJoue = new TaskCompletionSource<Mouvement>(annulation);
                nbDePrisesTmp = 0;

                try
                {
                    mouvFinal = aJoue.Task.Result;

                }
                catch (AggregateException)
                {
                    throw new OperationCanceledException();
                }
                

                Console.WriteLine("mouv choisi");
                Plateau test = new Plateau(plateau);
                valide = test.Effectuer(mouvFinal, EstBlanc);

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
            return mouvFinal;
        }

        public void OnCaseSelectionnee(Object sender, SelectionCaseEventArg e)
        {
            if (e.Handled || !aLeTrait) return;
            
            if (!e.Selectionnee)
            {
                if(mouvement == null)
                {
                    var debut = new Coords((sbyte)e.X, (sbyte)e.Y);
                    if(plateauTMP.Get(debut)?.EstBlanc == EstBlanc)
                    {
                        mouvement = new Mouvement(debut);
                        Console.WriteLine("debut mouv");
                        e.Selectionnee = true;
                        deselectionnerToutesLesCases += e.Deselectionner;
                    }
                    else
                    {
                        e.Selectionnee = false;
                    }
                    
                }
                else
                {
                    Console.WriteLine("saut "+EstBlanc);
                    Piece piece = plateauTMP.Get(mouvement.Depart);
                    Coords choisie = new Coords((sbyte)e.X, (sbyte)e.Y);
                    if (piece.EstSimplementValide(plateauTMP, mouvement.DernierePosition(), choisie, ref nbDePrisesTmp))
                    {
                        mouvement.Sauts.Enqueue(choisie);
                        e.Selectionnee = true;
                        deselectionnerToutesLesCases += e.Deselectionner;
                    }
                    if(mouvement.GetNbPrises(plateauTMP) == plateauTMP.GetMaxPrisesPossible(EstBlanc))
                    {
                        e.Selectionnee = false;
                        aJoue.TrySetResult(mouvement);
                    }
                
                }
            }
            else
            {
                mouvement = null;
                deselectionnerToutesLesCases?.Invoke();
                deselectionnerToutesLesCases = null;
                e.Selectionnee = false;
            }

            e.Handled = true;
        }
    }
}
