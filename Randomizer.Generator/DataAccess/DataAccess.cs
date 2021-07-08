using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.DataAccess
{
	public static class DataAccess
	{
		private static IDataAccess _instance;
		public static IDataAccess Instance 
		{
			get
			{
				if (_instance == null)
				{
					_instance = new FileSystemDataAccess();
				}
				return _instance;
			}
			set => _instance = value; 
		}
	}
}
