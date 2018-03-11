using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IADames.Moteur
{
    abstract class Joueur
    {
        public readonly bool EstBlanc;

        protected Joueur(bool estBlanc)
        {
            EstBlanc = estBlanc;
        }

        public abstract Mouvement Jouer(Plateau plateau);
    }
}
