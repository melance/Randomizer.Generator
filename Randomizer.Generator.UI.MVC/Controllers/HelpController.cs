using Microsoft.AspNetCore.Mvc;
using Randomizer.Generator.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randomizer.Generator.UI.MVC.Controllers
{
	public class HelpController : Controller
	{
		public IActionResult Index(String category = "Overview", String topic = "Overview") => View(new HelpModel(category, topic));		
	}
}
