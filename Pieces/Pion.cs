using IAEchecs.Moteur;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace IAEchecs.Pieces
{
    class Pion : Piece
    {

        public Pion(bool estBlanc) : base(estBlanc)
        {
            
        }

        public override Piece Copier(Piece aCopier)
        {
            return new Pion(aCopier.EstBlanc);
        }

        public override IEnumerable<Coords> GetMouvementsPossibles(Plateau plateau, Coords position)
        {
            Coords tmp = position.Voisin(1, 1);
            if (Plateau.EstDansLePlateau(tmp)) yield return tmp;
            tmp = position.Voisin(1, 1);
            if (Plateau.EstDansLePlateau(tmp)) yield return tmp;
        }


        public override Image GetSprite()
        {
            return EstBlanc ? SpriteProvider.Instance.PionB : SpriteProvider.Instance.PionN;
        }

    }
}
