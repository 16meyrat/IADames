using IADames.Moteur;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IADames.Pieces
{
    class Dame : Piece
    {
        
        public Dame(bool estBlanc) : base(estBlanc)
        {
        }

        public override Piece Copier(Piece aCopier)
        {
            return new Dame(aCopier.EstBlanc);
        }

        public override IEnumerable<Coords> GetMouvementsPossibles(Plateau plateau, Coords position)
        {
            throw new NotImplementedException();
        }

        public override Image GetSprite()
        {
            return EstBlanc ? SpriteProvider.Instance.DameB : SpriteProvider.Instance.DameN;
        }
    }
}
