using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Assignment
{
    /// <summary>
    /// A list of line items
    /// </summary>
    public class LineItemList : List<LineItem>
    {
        #region Members
        private Int32? _totalWeight;
        #endregion

        #region Properties
        /// <summary>
        /// The total weight of all line items in this list
        /// </summary>
        public Int32 TotalWeight
        {
            get
            {
                if (!_totalWeight.HasValue)
                {
                    _totalWeight = this.Sum(i => i.Weight);
                }
                return _totalWeight.GetValueOrDefault(1);
            }
        }

        /// <summary>
        /// Selects a line item from the list at random
        /// </summary>
        public LineItem SelectRandomItem()
        {
            if (Count == 1)
            {
                return this.First();
            }
            else
            {
                var value = Utility.Random.RandomNumber(1, TotalWeight);
                var sum = 0;

                foreach (var item in this)
                {
                    sum += item.Weight;
                    if (sum >= value) return item;
                }
            }
            return null;
        }
        #endregion
    }
}
