using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randomizer.Generator.UI.MVC.Utility
{
	public class SessionIndexer
	{
		private readonly ISession _session;

		public SessionIndexer(ISession Session) => _session = Session;
		
		public String this[string key]
		{
			get
			{
				return _session.GetString(key);
			}
			set
			{
				_session.SetString(key, value);
			}
		}
	}
}
