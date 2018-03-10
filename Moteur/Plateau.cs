using IAEchecs.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IAEchecs.Moteur
{
    class Plateau
    {
        public Piece[,] Grille { get; private set; } = new Piece[8, 8];

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EstDansLePlateau(Coords coords)
        {
            return coords.X>=0 && coords.Y>=0 && coords.X < 8 && coords.Y < 8;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Piece Get(Coords coords)
        {
            return Grille[coords.X, coords.Y];
        }

    }
}
