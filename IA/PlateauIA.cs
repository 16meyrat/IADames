using IADames.Moteur;
using IADames.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IADames.IA
{
    public class PlateauIA
    {
        public PieceIA[,] Grille;

        public PlateauIA()
        {
            Grille = new PieceIA[Plateau.TAILLE, Plateau.TAILLE];
        }
        public PlateauIA(Plateau original)
        {
            Grille = new PieceIA[Plateau.TAILLE, Plateau.TAILLE];
            for(int i=0; i<Plateau.TAILLE; i++)
            {
                for(int j=0; j<Plateau.TAILLE; j++)
                {
                    if(original.Grille[i, j] is Pion)
                    {
                        Grille[i, j] = new PionIA(original.Grille[i, j].EstBlanc);
                    }else if(original.Grille[i, j] is Dame)
                    {
                        Grille[i, j] = new DameIA(original.Grille[i, j].EstBlanc);
                    }
                }
            }
        }
        public PlateauIA(PlateauIA autre)
        {
            Grille = new PieceIA[Plateau.TAILLE, Plateau.TAILLE];
            for (int i = 0; i < Plateau.TAILLE; i++)
            {
                for (int j = 0; j < Plateau.TAILLE; j++)
                {
                    if (autre.Grille[i, j] == null) continue;
                    if(autre.Grille[i, j] is PionIA)
                    {
                        Grille[i, j] = new PionIA(autre.Grille[i, j].EstBlanc);
                    }
                    else if (autre.Grille[i, j] is DameIA)
                    {
                        Grille[i, j] = new DameIA(autre.Grille[i, j].EstBlanc);
                    }
                }
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal PieceIA Get(Coords coords)
        {
            return Grille[coords.X, coords.Y];
        }
        internal bool EstTermine()
        {
            bool blancExiste = false;
            bool noirExiste = false;
            PieceIA tmpPiece = null;
            for (int j = Plateau.TAILLE-1; j >= 0; j--)
            {
                for (int i = 0; i < Plateau.TAILLE; i++)
                {
                    tmpPiece = Grille[i, j];
                    if (tmpPiece == null) continue;

                    if (tmpPiece.EstBlanc)
                    {
                        blancExiste = true;
                    }
                    else
                    {
                        noirExiste = true;
                    }

                    if (blancExiste && noirExiste) return false;

                }
            }
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void GetMouvementsPossibles(bool estBlanc, out List<Mouvement> mouvementsPossibles)
        {
            mouvementsPossibles = new List<Mouvement>();
            int nbCoupsObligatoire = 0;
            for (sbyte j = Plateau.TAILLE - 1; j >= 0; j--)
            {
                for (sbyte i = 0; i < Plateau.TAILLE; i++)
                {
                    if (Grille[i, j]?.EstBlanc == estBlanc)
                    {
                        Grille[i, j].MajMouvementsPossibles(this, new Coords(i, j), ref mouvementsPossibles, ref nbCoupsObligatoire);
                    }
                }
            }
        }

        public int Negamax(int depth, int alpha, int beta, bool estBlancTour)
        {
            if (depth == 0)
            {
                return Evaluer(estBlancTour);
            }
            if (EstTermine()) return (int.MinValue + 10);
            GetMouvementsPossibles(estBlancTour, out List<Mouvement> mouvementsPossibles);

            PlateauIA tmp;
            int maxi = int.MinValue;
            int tmpVal;
            for (int i =0; i<mouvementsPossibles.Count; i++)
            {
                tmp = new PlateauIA(this);
                tmp.Effectuer(mouvementsPossibles[i]);
                tmpVal = -tmp.Negamax(depth - 1, -beta, -alpha, !estBlancTour);
                maxi = Math.Max(tmpVal, maxi);
                alpha = Math.Max(tmpVal, alpha);
                if (alpha >= beta) break;
                
            }
            return maxi;

        }


        private int Evaluer(bool estBlanc)
        {
            int res = 0;
            for (int j = Plateau.TAILLE - 1; j >= 0; j--)
            {
                for (int i = 0; i < Plateau.TAILLE; i++)
                {
                    if(Grille[i, j] != null)
                    {
                        if(Grille[i, j].EstBlanc)
                        {
                            if (Grille[i, j] is DameIA) res += 9;
                            res++;
                        }
                        else
                        {
                            if (Grille[i, j] is DameIA) res -= 9;
                            res--;
                        }
                    }
                }
            }
            if (!estBlanc) {
                return -res;
                }
            return res;
        }
        //aucun test de véricafivation
        internal void Effectuer(Mouvement mouv)
        {
            PieceIA piece = Get(mouv.Depart);
            Coords origine = mouv.Depart;

            Coords tmp = new Coords();
            origine = mouv.Depart;
            Coords direction;
            Grille[origine.X, origine.Y] = null;
            foreach (var coord in mouv.Sauts)
            {
                direction = (coord - origine).GetVraiUnitaire();
                tmp = origine;
                do
                {
                    tmp += direction;
                    Grille[tmp.X, tmp.Y] = null;
                } while (tmp.X != coord.X);

                origine = coord;
            }
            //ici, origine vaut la derniere case du deplacement
            Grille[origine.X, origine.Y] = piece;

        }
    }
}
