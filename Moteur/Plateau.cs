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
            for(int y = 0; y < 5; y++)
            {
                for(int x = 0; x < 10; x++)
                {
                    if ((x + y) % 2 == 0)
                    {
                        Grille[x, y] = new Pion(true);
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

        internal bool Effectuer(Mouvement mouv, bool joueurEstBlanc)
        {
            Piece piece = Get(mouv.Depart);
            Coords origine = mouv.Depart;
            if (piece == null || piece.EstBlanc != joueurEstBlanc || mouv.Sauts.Count==0) return false;
            int nbPrises = 0;
            foreach(var coord in mouv.Sauts)
            {
                if (!piece.EstSimplementValide(this, origine, coord, ref nbPrises)) return false;
            }
            //verification du meilleur mouvement possible
            List<int> nbsPrises = new List<int>();
            for(int i=0; i< 10; i++)
            {
                for(int j=0; j<10; j++)
                {
                    if(Grille[i, j]?.EstBlanc == joueurEstBlanc)
                    {
                        nbsPrises.Add(Grille[i, j].GetMaxPrisesPossibles(this, new Coords((sbyte)i, (sbyte)j)));
                    }             
                }
            }

            return nbsPrises.Max() == nbPrises;

        }


    }
}
