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
        public IALouis(bool estBlanc) : base(estBlanc)
        {
        }

        public override Mouvement Jouer(Plateau plateau, CancellationToken annulation)
        {
            throw new NotImplementedException();
        }
    }
}
