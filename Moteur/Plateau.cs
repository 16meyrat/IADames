using IADames.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IADames.Moteur
{
    public class Plateau
    {
        public const byte TAILLE = 10;

        public Piece[,] Grille { get; private set; } = new Piece[TAILLE, TAILLE];
        public bool EstEchec { get; private set; } = false;

        public int TourSansAction { get; private set; }//TODO : parties nulles

        public Plateau(bool plein = true)
        {
            if (plein)
            {
                for (int x = 0; x < TAILLE; x++)
                {
                    for (int y = 0; y < 4; y++)
                    {
                        if ((x + y) % 2 == 0)
                        {
                            Grille[x, y] = new Pion(true);
                        }
                    }

                    for (int y = 6; y < TAILLE; y++)
                    {
                        if ((x + y) % 2 == 0)
                        {
                            Grille[x, y] = new Pion(false);
                        }
                    }
                }
            }

        }

        public Plateau(Plateau autre)
        {
            Grille = (Piece[,])autre.Grille.Clone();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EstDansLePlateau(Coords coords)
        {
            return coords.X >= 0 && coords.Y >= 0 && coords.X < TAILLE && coords.Y < TAILLE;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal Piece Get(Coords coords)
        {
            return Grille[coords.X, coords.Y];
        }

        internal int GetMaxPrisesPossible(bool joueurEstBlanc)
        {
            List<int> nbsPrises = new List<int>();
            for (int i = 0; i < TAILLE; i++)
            {
                for (int j = 0; j < TAILLE; j++)
                {
                    if (Grille[i, j]?.EstBlanc == joueurEstBlanc)
                    {
                        nbsPrises.Add(Grille[i, j].GetMaxPrisesPossibles(this, new Coords((sbyte)i, (sbyte)j)));
                    }
                }
            }

            return nbsPrises.Count>0?nbsPrises.Max():0;
        }

        internal bool Effectuer(Mouvement mouv, bool joueurEstBlanc)
        {
            Piece piece = Get(mouv.Depart);
            Coords origine = mouv.Depart;
            if (piece == null || piece.EstBlanc != joueurEstBlanc || mouv.Sauts.Count == 0) return false;
            int nbPrises = 0;
            foreach (var coord in mouv.Sauts)
            {
                if (!piece.EstSimplementValide(this, origine, coord, ref nbPrises)) return false;
                origine = coord;
            }
            //verification du meilleur mouvement possible
            if (nbPrises < GetMaxPrisesPossible(joueurEstBlanc))
            {
                Console.WriteLine("Il existe un coup qui prend plus de pions que " + nbPrises);
                return false;
            }

            //on a le meilleur mouvement, et il est valide : on peut l'effectuer

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
            return true;

        }

        internal bool EstTermine()
        {
            bool blancExiste = false;
            bool noirExiste = false;
            Piece tmpPiece = null;
            for (int j = 9; j >= 0; j--)
            {
                for (int i = 0; i < TAILLE; i++)
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

        public void Print()
        {
            for (int j = 9; j >= 0; j--)
            {
                for (int i = 0; i < TAILLE; i++)
                {
                    Console.Write(Grille[i, j]==null ? "____  " : Grille[i, j].ToString() + " ");
                }
                Console.Write('\n');
            }


        }
        public void FairePromotions()
        {
            for(int i =0; i< TAILLE; i++)
            {
                if(Grille[i, 0] is Pion && !Grille[i, 0].EstBlanc)
                {
                    Grille[i, 0] = new Dame(false);
                    return; //micro-optimisation, si on appelle cette fonction à la fin de chaque tour
                }
                if (Grille[i, TAILLE-1] is Pion && Grille[i, TAILLE-1].EstBlanc)
                {
                    Grille[i, TAILLE - 1] = new Dame(true);
                }
            }
        }


    }
}
