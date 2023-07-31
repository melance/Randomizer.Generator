using Randomizer.Generator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.DataAccess
{
	public class GetDefinitionListResponse : List<GetDefinitionResponse>
	{
		public void Add(BaseDefinition definition) => Add(new GetDefinitionResponse(definition));
		public void Add(String fileName, Exception exception) => Add(new GetDefinitionResponse(fileName, exception));
	}
}
