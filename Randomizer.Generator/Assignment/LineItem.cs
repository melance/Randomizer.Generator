using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Randomizer.Generator.Assignment
{
    /// <summary>
    /// A line item in the definition
    /// </summary>
    public class LineItem
    {
        #region Properties
        /// <summary>The content of the line item used for the generation</summary>
        public String Content { get; set; }
        /// <summary>The next item key to seek after processing this one</summary>
        public String Next { get; set; }
        /// <summary>How many times to repeat this line item</summary>
        public UInt32 Repeat { get; set; }
        /// <summary>If given a value, the outcome of this line is stored in a variable instead of being output</summary>
        public String Variable { get; set; }
        /// <summary>A weight given to the random selection of this line item</summary>
		[DefaultValue(1)]
        public UInt32 Weight { get; set; } = 1;
        #endregion
    }
}
