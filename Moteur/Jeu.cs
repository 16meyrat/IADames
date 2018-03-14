using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IADames.Moteur
{

    class Jeu
    {
        public Plateau Plateau { get; private set; }

        public Joueur JoueurB { get; private set; }
        public Joueur JoueurN { get; private set; }

        private IAffichageEchec ui;

        public Jeu(Joueur joueurB, Joueur joueurN, IAffichageEchec ui)
        {
            JoueurB = joueurB;
            JoueurN = joueurN;
            this.ui = ui;

            Plateau = new Plateau();
        }

        public async Task Jouer(CancellationToken annulation)
        {
            ui.AfficherPlateau(Plateau);

            await Task.Run(() =>
            {
                try
                {
                    while (true)
                    {
                        AfficherTour(true);
                        if (!Plateau.Effectuer(JoueurB.Jouer(new Plateau(Plateau), annulation), true))
                        {
                            Console.WriteLine("Les Blancs ont voulu jouer un coup incorrect");
                        }
                        Plateau.FairePromotions();
                        Console.WriteLine("fin tour Blancs");
                        ui.AfficherPlateau(Plateau);
                        VerifierGagnant(true);

                        AfficherTour(false);
                        if (!Plateau.Effectuer(JoueurN.Jouer(new Plateau(Plateau), annulation), false))
                        {
                            Console.WriteLine("Les Noirs ont voulu jouer un coup incorrect");
                        }
                        Plateau.FairePromotions();
                        Console.WriteLine("fin tour Noirs");
                        ui.AfficherPlateau(Plateau);
                        VerifierGagnant(false);
                    }
                }
                catch (OperationCanceledException)
                {
                    Console.Write("Partie Annulee ");
                    return;
                }
            }, annulation).ContinueWith((precedant)=>
            {
                Console.WriteLine(precedant.Status);
            });
        }

        private void AfficherTour(bool estBlanc)
        {
            var ret = Plateau.GetMaxPrisesPossible(estBlanc);
            if (ret> 0){
                ui.AfficherTour(estBlanc, "Les " + (estBlanc ? "Blancs" : "Noirs") + " doivent prendre " + ret + " pions.");
            }
            else
            {
                ui.AfficherTour(estBlanc, "C'est aux " + (estBlanc ? "Blancs" : "Noirs") + " de jouer.");
            }
        }

        private void VerifierGagnant(bool estBlanc)
        {
            if (Plateau.EstTermine())
            {
                ui.AfficherGagnant(estBlanc);
            }
        }
    }
}
