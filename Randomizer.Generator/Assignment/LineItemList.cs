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
        private UInt32? _totalWeight;
		private LineItemList _deck;
        #endregion

        #region Properties
		public Boolean Draw { get; set; }

		public String Variable { get; set; } = String.Empty;

        /// <summary>
        /// The total weight of all line items in this list
        /// </summary>
        public UInt32 TotalWeight
        {
            get
            {
                if (!_totalWeight.HasValue)
                {
                    _totalWeight = (UInt32?)this.Sum(i => i.Weight);
                }
                return _totalWeight.GetValueOrDefault(1);
            }
        }

        /// <summary>
        /// Selects a line item from the list at random
        /// </summary>
        public LineItem SelectRandomItem()
        {
			if (Draw) return DrawRandomItem();
            if (Count == 1)
            {
                return this.First();
            }
            else
            {
                var value = Utility.Random.RandomNumber(1, (Int32)TotalWeight);
                var sum = 0u;

                foreach (var item in this)
                {
                    sum += item.Weight;
                    if (sum >= value) return item;
                }
            }
            return null;
        }

		private LineItem DrawRandomItem()
		{
			if (_deck == null || _deck.Count == 0)
			{
				_deck = new();
				_deck.AddRange(this);
			}
			
			if (_deck.Count == 1)
			{
				var item = _deck.First();
				_deck.Clear();
				return item;
			}
			else
			{
				var value = Utility.Random.RandomNumber(1, (Int32)_deck.TotalWeight);
				var sum = 0u;
				for (Int32 i = 0; i < _deck.Count(); i++)
				{
					var item = _deck[i];
					sum += item.Weight;
					if (sum >= value)
					{
						_deck.Remove(item);
						_deck.RecalculateWeight();
						return item;
					}
				}
			}
			return null;
		}

		internal void RecalculateWeight() => _totalWeight = null;
        #endregion
    }
}
