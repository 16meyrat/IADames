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
        public Piece[,] Grille { get; private set; } = new Piece[10, 10];
        public bool EstEchec { get; private set; } = false;

        public Plateau()
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if ((x + y) % 2 == 0)
                    {
                        Grille[x, y] = new Pion(true);
                    }
                }

                for (int y = 6; y < 10; y++)
                {
                    if ((x + y) % 2 == 0)
                    {
                        Grille[x, y] = new Pion(false);
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
            return coords.X>=0 && coords.Y>=0 && coords.X < 10 && coords.Y < 10;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal Piece Get(Coords coords)
        {
            return Grille[coords.X, coords.Y];
        }

        internal int GetMaxPrisesPossible(bool joueurEstBlanc)
        {
            List<int> nbsPrises = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (Grille[i, j]?.EstBlanc == joueurEstBlanc)
                    {
                        nbsPrises.Add(Grille[i, j].GetMaxPrisesPossibles(this, new Coords((sbyte)i, (sbyte)j)));
                    }
                }
            }

            return nbsPrises.Max();
        }

        internal bool Effectuer(Mouvement mouv, bool joueurEstBlanc)
        {
            Piece piece = Get(mouv.Depart);
            Coords origine = mouv.Depart;
            if (piece == null || piece.EstBlanc != joueurEstBlanc || mouv.Sauts.Count==0) return false;
            int nbPrises = 0;
            foreach(var coord in mouv.Sauts)
            {
                if (!piece.EstSimplementValide(this, origine, coord, ref nbPrises)) return false;
                origine = coord;
            }
            //verification du meilleur mouvement possible
            if (nbPrises < GetMaxPrisesPossible(joueurEstBlanc))
            {
                Console.WriteLine("Il existe un coup qui prend plus de pions");
                return false;
            }

            //on a le meilleur mouvement, et il est valide : on peut l'effectuer
            
            Coords tmp = new Coords();
            origine = mouv.Depart;
            Grille[origine.X, origine.Y] = null;
            foreach (var coord in mouv.Sauts)
            {
                tmp = coord - origine;
                if (tmp.Longueur() == 2)
                {
                    tmp = origine + tmp / 2;
                    Grille[tmp.X, tmp.Y] = null;
                }
                origine = coord;
            }
            //ici, origine vaut la derniere case du deplacement
            Grille[origine.X, origine.Y] = piece;
            return true;

        }


    }
}
