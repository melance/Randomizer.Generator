using Randomizer.Generator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.DataAccess
{
	public class GetDefinitionResponse
	{
		public GetDefinitionResponse(BaseDefinition definition) => Definition = definition;
		public GetDefinitionResponse(String fileName, Exception exception) => (FileName, Exception) = (fileName, exception);

		public String FileName { get; set; } = String.Empty;
		public Exception? Exception { get; set; } = null;
		public BaseDefinition? Definition { get; set; } = null;
	}
}
