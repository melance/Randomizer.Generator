using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Win.Templates
{
	public partial class ExceptionTemplate
	{
		public Exception Ex { get; }

		public ExceptionTemplate(Exception ex) => Ex = ex;
	}
}
