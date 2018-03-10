using IADames.Moteur;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace IADames.Pieces
{
    public class Pion : Piece
    {

        public Pion(bool estBlanc) : base(estBlanc)
        {
            
        }

        public override Piece Copier(Piece aCopier)
        {
            return new Pion(aCopier.EstBlanc);
        }

        public override int GetMaxPrisesPossibles(Plateau plateau, Coords position)
        {

            Coords diag1 = new Coords(1, 1);
            Coords diag2 = new Coords(-1, 1);

            LinkedList<int> possibles = new LinkedList<int>(); // nombre de pieces qu'il est possible de prendre 

            GetMouvementsPossiblesRec(plateau, possibles, ref position, ref diag1, ref diag2);

            int maxi = int.MinValue;
            foreach(int prises in possibles)
            {
                if (maxi < prises)
                {
                    maxi = prises;
                }
            }
            return maxi;
            
        }

        private void GetMouvementsPossiblesRec(Plateau plateau, LinkedList<int> possibles, ref Coords origine, ref Coords direction1, ref Coords direction2, int nbPrises=0)
        {
            Coords tmpPos;
            Piece tmpPiece;
            tmpPos = origine + direction1;
            if (Plateau.EstDansLePlateau(tmpPos)) {
                tmpPiece = plateau.Get(tmpPos);
                if(tmpPiece == null)
                {
                    possibles.AddLast(nbPrises);
                }
                else if(tmpPiece.EstBlanc != EstBlanc && !tmpPiece.flag)
                {
                    // flag pour ne pas ressauter des pieces
                    tmpPos = tmpPos + direction1;
                    if(Plateau.EstDansLePlateau(tmpPos) && plateau.Get(tmpPos) == null)
                    {
                        tmpPiece.flag = true;
                        GetMouvementsPossiblesRec(plateau, possibles, ref tmpPos, ref direction1, ref direction2, nbPrises + 1);
                        tmpPiece.flag = false;
                    }
                }
            }
            tmpPos = origine + direction2;
            if (Plateau.EstDansLePlateau(tmpPos))
            {
                tmpPiece = plateau.Get(tmpPos);
                if (tmpPiece == null)
                {
                    possibles.AddLast(nbPrises);
                }
                else if (tmpPiece.EstBlanc != EstBlanc && !tmpPiece.flag)
                {
                    // flag pour ne pas ressauter des pieces
                    tmpPos = tmpPos + direction2;
                    if (Plateau.EstDansLePlateau(tmpPos) && plateau.Get(tmpPos) == null)
                    {
                        tmpPiece.flag = true;
                        GetMouvementsPossiblesRec(plateau, possibles, ref tmpPos, ref direction1, ref direction2, nbPrises + 1);
                        tmpPiece.flag = false;
                    }
                }
            }
        }

        public override Image GetSprite()
        {
            return EstBlanc ? SpriteProvider.Instance.PionB : SpriteProvider.Instance.PionN;
        }

        public override bool EstSimplementValide(Plateau plateau , Coords origine, Coords fin, ref int nbPrises)
        {
            if (!Plateau.EstDansLePlateau(fin)) return false;
            Coords distance = fin - origine;
            if (distance.EstDiag()){
                if(distance.Longueur() == 1)
                {
                    return plateau.Get(fin) == null;
                }
                else if(distance.Longueur() == 2 && plateau.Get(origine + distance / 2) != null)
                {
                    nbPrises++;
                    return plateau.Get(fin) == null;
                }
            }

            return false;
        }
    }
}
