using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IADames.Moteur {

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

    public async Task Jouer()
    {
        ui.AfficherPlateau(Plateau);
            await Task.Run(() => {
                while (true)
                {
                    ui.AfficherTour(true);
                    if (!Plateau.Effectuer(JoueurB.Jouer(Plateau), true))
                    {
                        Console.WriteLine("Les Blancs ont voulu jouer un coup incorrect");
                    }
                    Console.WriteLine("fin tour");
                    ui.AfficherPlateau(Plateau);

                    ui.AfficherTour(false);
                    if (!Plateau.Effectuer(JoueurN.Jouer(Plateau), false))
                    {
                        Console.WriteLine("Les Noirs ont voulu jouer un coup incorrect");
                    }
                    ui.AfficherPlateau(Plateau);
                }
            });
        
    }
}
}
