using IAEchecs.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAEchecs.Moteur
{
    class Mouvement
    {
        public Coords Depart { get; set; }
        public Coords Arrivee { get; set; }

        public Mouvement(Coords depart, Coords arrivee)
        {
            Depart = depart;
            Arrivee = arrivee;
        }

        public bool EstValide(Plateau plateau, bool couleurJoueur)
        {
            if (!Plateau.EstDansLePlateau(Depart)) return false;
            Piece piece = plateau.Get(Depart);
            if (piece == null) return false;
            if (piece.EstBlanc != couleurJoueur) return false;

            foreach(Coords destination in piece.GetMouvementsPossibles(plateau, Depart))
            {
                if (destination == Arrivee) return true;
            }
            return false;
        }
    }
}
