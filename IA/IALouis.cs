using IADames.IA;
using IADames.Moteur;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IAEchecs.IA
{
    class IALouis : Joueur
    {
        private int niveau;

        public IALouis(bool estBlanc, int niveau) : base(estBlanc)
        {
            this.niveau = niveau;
        }

        public override Mouvement Jouer(Plateau plateau, CancellationToken annulation)
        {
            PlateauIA plat = new PlateauIA(plateau);
            plat.GetMouvementsPossibles(out List<Mouvement> mouvementsPossibles);
            PlateauIA tmp;
            int maxi = int.MinValue;
            Mouvement meilleurMouv = mouvementsPossibles[0];//TODO : gérer les égalités
            int tmpVal;
            for (int i = 0; i < mouvementsPossibles.Count; i++)
            {
                tmp = new PlateauIA(plat);
                tmp.Effectuer(mouvementsPossibles[i]);
                tmpVal = tmp.Negamax(niveau, int.MinValue, int.MaxValue, EstBlanc);
                maxi = Math.Max(tmpVal, maxi);
                meilleurMouv = mouvementsPossibles[i];
            }
            Console.WriteLine(meilleurMouv);
            return meilleurMouv;
        }
    }
}
