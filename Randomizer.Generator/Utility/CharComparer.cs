using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Utility
{
    public class InsensitiveCharComparer : IComparer<Char>, IEqualityComparer<Char>, IComparer, IEqualityComparer
    {
        public InsensitiveCharComparer() { } 

        public Int32 Compare(Char x, Char y)
        {
            var xs = x.ToString();
            var ys = y.ToString();
            return StringComparer.CurrentCultureIgnoreCase.Compare(xs, ys);
        }

        public Int32 Compare(Object x, Object y)
        {
            if (x == y) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            var xs = x as Char?;
            
            if (xs != null)
            {
                var ys = y as Char?;
                if (ys != null)
                    return Compare(xs, ys);
            }

            IComparable ix = x as IComparable;
            if (ix != null)
            {
                return ix.CompareTo(y);
            }

            throw new ArgumentException($"Could not find implementation of IComparabale for {x?.GetType()}");
        }

        public Boolean Equals(Char x, Char y)
        {
            return StringComparer.CurrentCultureIgnoreCase.Equals(x.ToString(), y.ToString());
        }

        public new Boolean Equals(Object x, Object y)
        {
            if (x == y) return true;
            if (x == null || y == null) return false;

            var xs = x as Char?;

            if (xs != null)
            {
                var ys = y as Char?;
                if (ys != null)
                    return Equals(xs, ys);
            }

            return x.Equals(y);
        }

        public Int32 GetHashCode([DisallowNull] Char obj)
        {
            return StringComparer.CurrentCultureIgnoreCase.GetHashCode(obj.ToString());
        }

        public Int32 GetHashCode(Object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            var c = obj as Char?;
            if (c != null)
            {
                return GetHashCode(c);
            }
            return obj.GetHashCode();
        }
    }
}