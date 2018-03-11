using System.Threading;

namespace IADames.Moteur
{
    abstract class Joueur
    {
        public readonly bool EstBlanc;

        protected Joueur(bool estBlanc)
        {
            EstBlanc = estBlanc;
        }

        public abstract Mouvement Jouer(Plateau plateau, CancellationToken annulation);
    }
}
