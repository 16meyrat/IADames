using IAEchecs.Moteur;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAEchecs.Pieces
{
    class Fou : Piece
    {
        
        public Fou(bool estBlanc) : base(estBlanc)
        {
        }

        public override Piece Copier(Piece aCopier)
        {
            return new Fou(aCopier.EstBlanc);
        }

        public override IEnumerable<Coords> GetMouvementsPossibles(Plateau plateau, Coords position)
        {
            throw new NotImplementedException();
        }

        public override Image GetSprite()
        {
            return EstBlanc ? SpriteProvider.Instance.FouB : SpriteProvider.Instance.FouN;
        }
    }
}
