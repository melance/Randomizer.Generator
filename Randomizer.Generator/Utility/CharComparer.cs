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
	/// <summary>
	/// A case insensitive comparer for <see cref="Char"/>
	/// </summary>
    public class InsensitiveCharComparer : IComparer<Char>, IEqualityComparer<Char>, IComparer, IEqualityComparer
    {
        public InsensitiveCharComparer() { }

		/// <summary>
		/// Compares two <see cref="Char"/> and returns their relative sort order
		/// </summary>
		/// <param name="x">The <see cref="Char"/> to compare <paramref name="y"/> to</param>
		/// <param name="y">The <see cref="Char"/> to compare <paramref name="x"/> to</param>
		/// <returns> A signed integer that indicates the relative values of <paramref name="x"/> and <paramref name="y"/>, as shown in the
		///     following table.<br />
		///     Value – Meaning<br />
		///     Less than zero – x precedes y in the sort order, or x is null and y is not null.<br />
		///     Zero – x is equal to y, or x and y are both null.<br />
		///     Greater than zero – x follows y in the sort order, or y is null and x is not null.<br />
		/// </returns>
		public Int32 Compare(Char x, Char y)
        {
            var xs = x.ToString();
            var ys = y.ToString();
            return StringComparer.CurrentCultureIgnoreCase.Compare(xs, ys);
        }

		/// <summary>
		/// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
		/// </summary>
		/// <param name="x">The first object to compare.</param>
		/// <param name="y">second object to compare.</param>
		/// <returns>A signed integer that indicates the relative values of x and y: 
		///		- If less than 0, x is less than y.<br/> 
		///		- If 0, x equals y. <br />
		///		- If greater than 0, x is greater than y.</returns>
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
                    return Compare((char)xs, (char)ys);
            }

			if (x is IComparable ix)
			{
				return ix.CompareTo(y);
			}

			throw new ArgumentException($"Could not find implementation of IComparabale for {x?.GetType()}");
        }

		/// <summary>
		/// Indicates whether two <see cref="Char"/> are equal.
		/// </summary>
		/// <param name="x">A <see cref="Char"/> to compare to <paramref name="y"/></param>
		/// <param name="y">A <see cref="Char"/> to compare to <paramref name="x"/></param>
		/// <returns><see cref="true"/> if <paramref name="x"/> and <paramref name="y"/> are equal; otherwise <see cref="false"/></returns>
		public Boolean Equals(Char x, Char y)
        {
            return StringComparer.CurrentCultureIgnoreCase.Equals(x.ToString(), y.ToString());
        }

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="x">A <see cref="Object"/> to compare to <paramref name="y"/></param>
		/// <param name="y">A <see cref="Object"/> to compare to <paramref name="x"/></param>
		/// <returns><see cref="true"/> if the objects are equal; otherwise <see cref="false"/></returns>
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

		/// <summary>
		/// Gets the hash code for the specified char.
		/// </summary>
		/// <param name="obj">The <see cref="Char"/> to get the has code for</param>
		/// <returns>The has code for <paramref name="obj"/></returns>
		public Int32 GetHashCode([DisallowNull] Char obj)
        {
            return StringComparer.CurrentCultureIgnoreCase.GetHashCode(obj.ToString());
        }

		/// <summary>
		/// Gets the hash code for the specified <see cref="Object"/>.
		/// </summary>
		/// <param name="obj">The <see cref="Object"/> to get the has code for</param>
		/// <returns>The has code for <paramref name="obj"/></returns>
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