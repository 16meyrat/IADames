using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IADames.Pieces
{
    public struct Coords:IEquatable<Coords>
    {
        public readonly sbyte X;
        public readonly sbyte Y;


        public Coords(sbyte x = -42, sbyte y= -42)
        {
            X = x;
            Y = y;
        }

        //case voisine de (plusX, plusY)
        public Coords Voisin(sbyte plusX, sbyte plusY)
        {
            return new Coords((sbyte)(X + plusX), (sbyte)(Y + plusY));
        }
        public bool EstNull()
        {
            return X == -42 && Y == -42;
        }

        public bool EstDiag() => Math.Abs(X) == Math.Abs(Y);

        public int Longueur() => Math.Abs(X);

        public static bool operator ==(Coords l, Coords r) => l.X == r.X && l.Y == r.Y;

        public static bool operator !=(Coords l, Coords r) => !(r == l);

        public bool Equals(Coords other) => X == other.X && Y== other.Y;

        public override bool Equals(object obj)
        {
            return obj.GetType() == GetType() && Equals((Coords)obj);
        }

        public static Coords operator +(Coords a, Coords b) => new Coords((sbyte)(a.X + b.X), (sbyte)(a.Y + b.Y));

        public static Coords operator -(Coords a, Coords b) => new Coords((sbyte)(a.X - b.X), (sbyte)(a.Y - b.Y));

        public static Coords operator /(Coords a, sbyte b) => new Coords((sbyte)(a.X / b), (sbyte)(a.Y / b));
        public static Coords operator *(Coords a, sbyte b) => new Coords((sbyte)(a.X * b), (sbyte)(a.Y * b));


        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }
    }
}
