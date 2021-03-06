﻿using IADames.Moteur;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IADames.Pieces
{

    public abstract class Piece
    {
        internal bool flag = false; // ce flag doit etre nettoye apres utilisation. A utiliser pour ce qu'on veut 

        public static readonly Coords[] DIRECTIONS = { new Coords(1, 1), new Coords(-1, 1), new Coords(-1, -1), new Coords(1, -1) };

        public static readonly Coords DIAG1 = new Coords(1, 1);
        public static readonly Coords DIAG2 = new Coords(1, -1);

        public Piece(bool estBlanc)
        {
            EstBlanc = estBlanc;
        }
        public abstract Piece Copier(Piece aCopier);

        public readonly bool EstBlanc;

        public abstract int GetMaxPrisesPossibles(Plateau plateau, Coords position);

        public abstract bool EstSimplementValide(Plateau plateau, Coords origine, Coords fin, ref int nbPrises);

        public abstract Image GetSprite();

    }
}
