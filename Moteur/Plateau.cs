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
        internal Piece[,] Grille { get; private set; } = new Piece[10, 10];
        public bool EstEchec { get; private set; } = false;

        public Plateau()
        {
            for(int x=0; x<10; x++)
            {
                Grille[x, 1] = new Pion(true);
                Grille[x, 8] = new Pion(false);

                //TODO autres pieces
            }
           
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
            if (!mouv.EstValide(this, joueurEstBlanc)) return false;
            Grille[mouv.Arrivee.X, mouv.Arrivee.Y] = Get(mouv.Depart);
            Grille[mouv.Depart.X, mouv.Depart.Y] = null;
            return true;

        }


    }
}
