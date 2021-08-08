﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Randomizer.Generator.Core;
using Randomizer.Generator.UI.MVC.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Randomizer.Generator.Exceptions;

namespace Randomizer.Generator.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
		private static Utility.Settings Settings;
		private static Utility.MVCDataAccess DataAccess => (Utility.MVCDataAccess)Generator.DataAccess.DataAccess.Instance;

		public HomeController(Utility.MVCDataAccess dataAccess, IOptions<Utility.Settings> settings)
		{
			Settings = settings.Value;
			Utility.MVCDataAccess.DefinitionsPath = String.Empty;
			Generator.DataAccess.DataAccess.Instance = new Utility.MVCDataAccess(Settings.DefinitionsPath);
		}

		[HttpGet]
        public IActionResult Index()
        {
			try
			{
				var model = new IndexModel(DataAccess, 1);
				ViewBag.ErrorMessage = String.Empty;
				return View(model);
			}
			catch (Exception ex)
			{
				var model = new IndexModel();
				ViewBag.ErrorMessage = ex.Message;
				foreach (var key in ex.Data.Keys)
				{
					ViewBag.ErrorMessage += $"<br/>{key}: {ex.Data[key]}";
				}
				return View(model);
			}
        }

		[HttpPost]
		public IActionResult Index(IndexModel model, Int32 page = 1)
		{
			model.GetDefinitions(DataAccess);
			return View(model);
		}

		[HttpGet]
		public IActionResult Definition(String name)
		{
			var model = (GeneratorModel)DataAccess.GetDefinition(name);
			return View(model);
		}

		[HttpPost]
		public IActionResult Definition(GeneratorModel model)
		{
			try
			{
				var results = new List<String>();
				var definition = DataAccess.GetDefinition(model.Name);
				
				foreach (var parameter in model.Parameters)
				{
					definition.Parameters[parameter.Key].Value = parameter.Value.Value;
				}

				for (var i = 1; i <= model.Repeat; i++)
				{
					results.Add(definition.Generate());
				}

				model = (GeneratorModel)definition;

				if (definition.OutputFormat == OutputFormats.Html)
					model.Result = String.Join("<br /><hr />", results.ToArray());
				else
					model.Result = String.Join("\n\n", results.ToArray());
			}
			catch (Exception ex)
			{
				model.ErrorMessage = Utility.ExceptionHandling.GetExceptionDetails(ex, Settings.FullExceptions);				
			}
			return View(model);
		}

        public IActionResult About()
        {
			var model = new AboutModel();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

		public IActionResult RawView(String name)
		{
			return Content(DataAccess.GetDefinitionRaw(name));
		}

    }
}