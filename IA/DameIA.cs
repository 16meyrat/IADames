using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IADames.Moteur;
using IADames.Pieces;

namespace IADames.IA
{
    class DameIA : PieceIA
    {

        public DameIA(bool estBlanc) : base(estBlanc)
        {
        }

        internal override void MajMouvementsPossibles(PlateauIA plateau, ref Coords position, ref List<Mouvement> autresMouvements, ref int valeurDesPrecedents)
        {
            throw new NotImplementedException();
        }
    }
}
