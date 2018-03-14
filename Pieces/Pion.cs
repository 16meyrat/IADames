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

            Coords diag1 = EstBlanc?new Coords(1, 1):new Coords(1, -1);
            Coords diag2 = EstBlanc?new Coords(-1, 1) : new Coords(-1, -1);

            LinkedList<int> possibles = new LinkedList<int>(); // nombre de pieces qu'il est possible de prendre 

            GetMouvementsPossiblesRec(plateau, possibles, ref position);

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
        private Coords[] GetDirections()
        {
            if (EstBlanc)
            {
                return new Coords[] { new Coords(1, 1), new Coords(-1, 1), new Coords(1, -1), new Coords(-1, -1) };
            }
            else{
                return new Coords[] { new Coords(1, -1), new Coords(-1, -1), new Coords(1, 1), new Coords(-1, 1)  };
            }
        }

        private void GetMouvementsPossiblesRec(Plateau plateau, LinkedList<int> possibles, ref Coords origine,  int nbPrises=0)
        {
            Coords tmpPos;
            Piece tmpPiece;
            Coords[] directions = GetDirections();

            possibles.AddLast(nbPrises);
            for (int i=0; i<4; i++)
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
                            tmpPiece.flag = true;
                            GetMouvementsPossiblesRec(plateau, possibles, ref tmpPos, nbPrises + 1);
                            tmpPiece.flag = false;
                        }
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
            Coords diag1 = EstBlanc ? new Coords(-1, 1) : new Coords(-1, -1);
            Coords diag2 = EstBlanc ? new Coords(1, 1) : new Coords(1, -1);

            if (distance.EstDiag()){
                if (distance.Longueur() == 1)
                {
                    if (distance != diag1 && distance != diag2) return false;
                    return plateau.Get(fin) == null;
                }
                else if (distance.Longueur() == 2) {
                    Piece tmp = plateau.Get(origine + distance / 2); 
                    if (tmp!=null && tmp.EstBlanc != EstBlanc)
                    {
                        nbPrises++;
                        return plateau.Get(fin) == null;
                    }
                }
            }

            return false;
        }

        public override string ToString()
        {
            return "pion";
        }
    }
}
