using IADames.Moteur;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IADames.Pieces
{
    public class Dame : Piece
    {

        public Dame(bool estBlanc) : base(estBlanc)
        {
        }

        public override Piece Copier(Piece aCopier)
        {
            return new Dame(aCopier.EstBlanc);
        }

        public override bool EstSimplementValide(Plateau plateau, Coords origine, Coords fin, ref int nbPrises)
        {
            if (!Plateau.EstDansLePlateau(fin)) return false;
            Coords deplacement = fin - origine;

            if (deplacement.EstDiag() && deplacement.Longueur() > 0)
            {
                deplacement = deplacement.GetVraiUnitaire();
                bool dejaPrise = false;
                var tmp = origine;
                Piece tmpPiece = null;
                while (tmp.X != fin.X)//on se déplace en diagonale, pas besoin de tout comparer
                {
                    tmp += deplacement;
                    tmpPiece = plateau.Get(tmp);
                    if (tmpPiece != null)
                    {
                        if (dejaPrise)
                        {
                            return false;
                        }
                        else
                        {
                            dejaPrise = true;
                        }
                        if (tmpPiece.EstBlanc == EstBlanc) return false;
                    }
                }
                if (tmpPiece == null)
                {
                    if (dejaPrise)
                    {
                        nbPrises++;
                    }
                    return true;
                }

            }

            return false;
        }
        //moins de tests que la version SimplementValide
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool EstMinimalementValide(Plateau plateau, Coords origine, Coords fin, Coords unitaire, ref int nbPrises, ref Piece sautee)
        {
            if (!Plateau.EstDansLePlateau(fin)) return false;

            bool dejaPrise = false;
            var tmp = origine;
            Piece tmpPiece = null;
            while (tmp != fin)//on se déplace en diagonale, pas besoin de tout comparer TODO:
            {
                tmp += unitaire;
                tmpPiece = plateau.Get(tmp);
                if (tmpPiece != null)
                {
                    if (dejaPrise || tmpPiece.flag)
                    {
                        return false;
                    }
                    else
                    {
                        dejaPrise = true;
                        sautee = tmpPiece;
                    }
                    if (tmpPiece.EstBlanc == EstBlanc) return false;
                }
            }
            if (tmpPiece == null)
            {
                if (dejaPrise)
                {
                    nbPrises++;
                }
                return true;
            }
            return false;
           
            
        }

        private void GetMouvementsPossiblesRec(Plateau plateau, LinkedList<int> possibles, ref Coords origine, Coords directionOrigineDirecteur, int nbPrises = 0)
        {
            possibles.AddLast(nbPrises);
            Coords tmpPos = origine;
            Piece tmpPiece = null;
            Coords direction = directionOrigineDirecteur;
            int tmpPrises = 0;
            bool invalideUneFois = false;

            while (true)
            {
                tmpPos += direction;
                tmpPrises = nbPrises;
                if (EstMinimalementValide(plateau, origine, tmpPos, direction, ref tmpPrises, ref tmpPiece))
                {
                    if (tmpPrises > nbPrises)
                    {
                        tmpPiece.flag = true;
                        GetMouvementsPossiblesRec(plateau, possibles, ref tmpPos, direction, tmpPrises);
                        tmpPiece.flag = false;
                    }

                }
                else
                {
                    if (invalideUneFois)
                    {
                        invalideUneFois = false;
                        break;
                    }
                    invalideUneFois = true;
                }

            }
            if (directionOrigineDirecteur.GetVraiUnitaire() == DIAG1)
            {
                direction = DIAG2;
            }
            else
            {
                direction = DIAG1;
            }
            tmpPos = origine;
            while (true)
            {
                tmpPos += direction;
                tmpPrises = nbPrises;
                if (EstMinimalementValide(plateau, origine, tmpPos, direction,  ref tmpPrises, ref tmpPiece)){
                    if(tmpPrises > nbPrises)
                    {
                        tmpPiece.flag = true;
                        GetMouvementsPossiblesRec(plateau, possibles, ref tmpPos, direction, tmpPrises);
                        tmpPiece.flag = false;
                    }
                    
                }
                else
                {
                    if (invalideUneFois)
                    {
                        invalideUneFois = false;
                        break;
                    }
                    invalideUneFois = true;
                }

            }
            tmpPos = origine;
            while (true)
            {
                tmpPos -= direction; // la difference est la
                tmpPrises = nbPrises;
                if (EstMinimalementValide(plateau, origine, tmpPos, -direction, ref tmpPrises, ref tmpPiece))
                {
                    if (tmpPrises > nbPrises)
                    {
                        tmpPiece.flag = true;
                        GetMouvementsPossiblesRec(plateau, possibles, ref tmpPos, direction, tmpPrises);
                        tmpPiece.flag = false;
                    }

                }
                else
                {
                    if (invalideUneFois)
                    {
                        invalideUneFois = false;
                        break;
                    }
                    invalideUneFois = true;
                }

            }

        }



        public override int GetMaxPrisesPossibles(Plateau plateau, Coords position)
        {
            LinkedList<int> possibles = new LinkedList<int>(); // nombre de pieces qu'il est possible de prendre 

            GetMouvementsPossiblesRec(plateau, possibles, ref position, DIAG1, 0);
            GetMouvementsPossiblesRec(plateau, possibles, ref position, DIAG2, 0);

           /* foreach(var res in possibles)
            {
                Console.WriteLine(res);
            }*/

            int maxi = int.MinValue;
            foreach (int prises in possibles)
            {
                if (maxi < prises)
                {
                    maxi = prises;
                }
            }
            return maxi;
        }

        public override Image GetSprite()
        {
            return EstBlanc ? SpriteProvider.Instance.DameB : SpriteProvider.Instance.DameN;
        }

        public override string ToString()
        {
            return "dame";
        }
    }
}
