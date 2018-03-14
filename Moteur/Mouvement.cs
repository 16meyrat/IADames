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
        public Mouvement(Mouvement autre)
        {
            Depart = autre.Depart;
            Sauts = new Queue<Coords>(autre.Sauts);
        }
        public Coords DernierePosition()
        {
            return Sauts.Count > 0 ? Sauts.Last() : Depart;
        }

        public int GetNbPrises(Plateau plateau)
        {
            if (Sauts.Count > 1)
            {
                return Sauts.Count;
            }
            else
            {
                if (Sauts.Count == 0) return -1;
                Coords distance = Sauts.Peek() - Depart; //file d'attente vide ????
                distance = distance / (sbyte)distance.Longueur();
                Coords tmp = Depart;
                while(tmp != Sauts.Peek())
                {
                    tmp = tmp + distance;
                    if (plateau.Get(tmp) != null)
                    {
                        return 1;
                    }
                }
                return 0;
            }
            
        }

      
    }
}
