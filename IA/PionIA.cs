using IADames.Moteur;
using IADames.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IADames.IA
{
    class PionIA :PieceIA
    {
        public PionIA(bool estBlanc) : base(estBlanc)
        {
        }


        internal override void MajMouvementsPossibles(PlateauIA plateau, ref Coords position, ref List<Mouvement> autresMouvements, ref int valeurDesPrecedents)
        {


            Stack<Tuple<int, Mouvement>> possibles = new Stack<Tuple<int, Mouvement>>();

            GetMouvementsPossiblesRec(plateau, possibles, ref position, new Mouvement(position));

            Tuple<int, Mouvement> tmp;
            while (possibles.Count > 0)
            {
                tmp = possibles.Pop();
                if (tmp.Item1 > valeurDesPrecedents)
                {
                    autresMouvements.Clear();
                    valeurDesPrecedents = tmp.Item1;
                    autresMouvements.Add(tmp.Item2);
                }else if(tmp.Item1 == valeurDesPrecedents)
                {
                    autresMouvements.Add(tmp.Item2);
                }
            }
        }
        protected Coords[] GetDirections()
        {
            if (EstBlanc)
            {
                return new Coords[] { new Coords(1, 1), new Coords(-1, 1), new Coords(1, -1), new Coords(-1, -1) };
            }
            else
            {
                return new Coords[] { new Coords(1, -1), new Coords(-1, -1), new Coords(1, 1), new Coords(-1, 1) };
            }
        }


        private void GetMouvementsPossiblesRec(PlateauIA plateau, Stack<Tuple<int, Mouvement>> possibles, ref Coords origine, Mouvement coups,int nbPrises = 0)
        {
            Coords tmpPos;
            PieceIA tmpPiece;
            Coords[] directions = GetDirections();

            possibles.Push(new Tuple<int, Mouvement>(nbPrises, coups));
            for (int i = 0; i < 4; i++)
            {
                tmpPos = origine + directions[i];
                if (Plateau.EstDansLePlateau(tmpPos))
                {
                    tmpPiece = plateau.Get(tmpPos);
                    if (tmpPiece != null && tmpPiece.EstBlanc != EstBlanc && !tmpPiece.flag)
                    {

                        tmpPos = tmpPos + directions[i];
                        if (Plateau.EstDansLePlateau(tmpPos) && plateau.Get(tmpPos) == null)
                        {
                            // flag pour ne pas ressauter des pieces
                            var tmp = new Mouvement(coups);
                            coups.Sauts.Enqueue(tmpPos);
                            tmpPiece.flag = true;
                            GetMouvementsPossiblesRec(plateau, possibles, ref tmpPos, tmp, nbPrises + 1);
                            tmpPiece.flag = false;
                        }
                    }
                }
            }


        }
    }
}
