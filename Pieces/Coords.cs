using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IADames.Pieces
{
    public class Coords:IEquatable<Coords>
    {
        public readonly sbyte X;
        public readonly sbyte Y;

        public Coords(sbyte x, sbyte y)
        {
            X = x;
            Y = y;
        }

        //case voisine de (plusX, plusY)
        public Coords Voisin(sbyte plusX, sbyte plusY)
        {
            return new Coords((sbyte)(X + plusX), (sbyte)(Y + plusY));
        }

        public static bool operator ==(Coords l, Coords r) => Equals(l, r);

        public static bool operator !=(Coords l, Coords r) => !(r == l);

        public bool Equals(Coords other) => X == other.X && Y== other.Y;

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == GetType() && Equals((Coords)obj);
        }

        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }
    }
}
