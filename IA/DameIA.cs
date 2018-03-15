using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using IADames.Moteur;
using IADames.Pieces;

namespace IADames.IA
{
    public class DameIA : PieceIA
    {

        public DameIA(bool estBlanc) : base(estBlanc)
        {
        }

        internal override void MajMouvementsPossibles(PlateauIA plateau, Coords position, ref List<Mouvement> autresMouvements, ref int valeurDesPrecedents)
        {

            Stack<Tuple<int, Mouvement>> possibles = new Stack<Tuple<int, Mouvement>>();

            GetMouvementsPossiblesRec(plateau, possibles, new Mouvement(position), ref position , DIAG1);
            GetMouvementsPossiblesRec(plateau, possibles, new Mouvement(position), ref position, DIAG2);

            Tuple<int, Mouvement> tmp;
            while (possibles.Count > 0)
            {
                tmp = possibles.Pop();
                if (tmp.Item1 > valeurDesPrecedents)
                {
                    autresMouvements.Clear();
                    valeurDesPrecedents = tmp.Item1;
                    autresMouvements.Add(tmp.Item2);
                }
                else if (tmp.Item1 == valeurDesPrecedents)
                {
                    autresMouvements.Add(tmp.Item2);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool EstMinimalementValide(PlateauIA plateau, Coords origine, Coords fin, Coords unitaire, ref int nbPrises, ref PieceIA sautee)
        {
            if (!Plateau.EstDansLePlateau(fin)) return false;

            bool dejaPrise = false;
            var tmp = origine;
            PieceIA tmpPiece = null;
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
        private void GetMouvementsPossiblesRec(PlateauIA plateau, Stack<Tuple<int, Mouvement>> possibles, Mouvement coups, ref Coords origine, Coords directionOrigineDirecteur, int nbPrises = 0)
        {
            if(coups.Sauts.Count>0)
                possibles.Push(new Tuple<int, Mouvement>(nbPrises, coups));
            
            Coords tmpPos = origine;
            PieceIA tmpPiece = null;
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
                        var tmpCoups = new Mouvement(coups);
                        tmpCoups.Sauts.Enqueue(tmpPos);
                        GetMouvementsPossiblesRec(plateau, possibles, tmpCoups, ref tmpPos, direction, tmpPrises);
                        tmpPiece.flag = false;
                    }
                    else
                    {
                        var tmpCoups = new Mouvement(coups);
                        tmpCoups.Sauts.Enqueue(tmpPos);
                        possibles.Push(new Tuple<int, Mouvement>(nbPrises, tmpCoups));
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
                if (EstMinimalementValide(plateau, origine, tmpPos, direction, ref tmpPrises, ref tmpPiece))
                {
                    if (tmpPrises > nbPrises)
                    {
                        var tmpCoups = new Mouvement(coups);
                        tmpCoups.Sauts.Enqueue(tmpPos);
                        tmpPiece.flag = true;
                        GetMouvementsPossiblesRec(plateau, possibles, tmpCoups, ref tmpPos, direction, tmpPrises);
                        tmpPiece.flag = false;
                    }
                    else if (coups.Sauts.Count==0)
                    {
                        var tmpCoups = new Mouvement(coups);
                        tmpCoups.Sauts.Enqueue(tmpPos);
                        possibles.Push(new Tuple<int, Mouvement>(nbPrises, tmpCoups));
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
                        var tmpCoups = new Mouvement(coups);
                        tmpCoups.Sauts.Enqueue(tmpPos);
                        tmpPiece.flag = true;
                        GetMouvementsPossiblesRec(plateau, possibles, tmpCoups, ref tmpPos, -direction, tmpPrises);
                        tmpPiece.flag = false;
                    }
                    else if (coups.Sauts.Count == 0)
                    {
                        var tmpCoups = new Mouvement(coups);
                        tmpCoups.Sauts.Enqueue(tmpPos);
                        possibles.Push(new Tuple<int, Mouvement>(nbPrises, tmpCoups));
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
    }
}
