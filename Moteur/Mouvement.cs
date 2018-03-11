using IADames.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IADames.Moteur
{
    class Mouvement
    {
        public Coords Depart { get; set; }
        public Queue<Coords> Sauts { get; private set; }

        public Mouvement(Coords depart, Coords arrivee):this(depart)
        {
            Sauts.Enqueue(arrivee);
        }
        public Mouvement(Coords depart)
        {
            Depart = depart;
            Sauts = new Queue<Coords>();
        }
        public Coords DernierePosition()
        {
            return Sauts.Count > 0 ? Sauts.Last() : Depart;
        }

      
    }
}
