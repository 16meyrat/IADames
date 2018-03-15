using IADames.Moteur;
using IADames.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IADames.IA
{

    public abstract class PieceIA
    {
        internal bool flag = false; // ce flag doit etre nettoye apres utilisation. A utiliser pour ce qu'on veut 

        public readonly bool EstBlanc;

        public static readonly Coords[] DIRECTIONS = { new Coords(1, 1), new Coords(-1, 1), new Coords(-1, -1), new Coords(1, -1) };

        public static readonly Coords DIAG1 = new Coords(1, 1);
        public static readonly Coords DIAG2 = new Coords(1, -1);

        public PieceIA(bool estBlanc)
        {
            EstBlanc = estBlanc;
        }
        internal abstract void MajMouvementsPossibles(PlateauIA plateau, Coords position, ref List<Mouvement> autresMouvements, ref int valeurDesPrecedents);//prend en compte la piece dans la liste des mouvements possibles

    }
}
