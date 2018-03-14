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
    class PlateauIA
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
        

    }
}
