using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAEchecs.Moteur
{
    abstract class Joueur
    {
        public readonly bool EstBlanc;

        protected Joueur(bool estBlanc)
        {
            EstBlanc = estBlanc;
        }

        public abstract Task<Mouvement> JouerAsync(Plateau plateau);
    }
}
