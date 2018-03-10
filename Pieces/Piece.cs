using IADames.Moteur;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IADames.Pieces
{

    abstract class Piece
    {
        public Piece(bool estBlanc)
        {
            EstBlanc = estBlanc;
        }
        public abstract Piece Copier(Piece aCopier);

        public readonly bool EstBlanc;

        public abstract IEnumerable<Coords> GetMouvementsPossibles(Plateau plateau, Coords position);

        public abstract Image GetSprite();

    }
}
