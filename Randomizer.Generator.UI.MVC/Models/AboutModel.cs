using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Randomizer.Generator.UI.MVC.Models
{
	public class AboutModel
	{
		public String Version { get => Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion; }
		public DateTime BuildDate { get => AssemblyInfo.CompilationTimestampUtc.ToLocalTime(); }
	}
}
