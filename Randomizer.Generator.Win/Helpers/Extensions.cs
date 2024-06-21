using Markdig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Win.Helpers
{
	internal static class Extensions
	{
		public static MarkdownPipeline Pipeline { get; } = new MarkdownPipelineBuilder()
															   .UseAdvancedExtensions()
															   .UseAutoIdentifiers()
															   .UseBootstrap()
															   .Build();

		public static String ToHTML(this Exception ex)
		{
			if (ex == null)
				return String.Empty;
			var template = new Templates.ExceptionTemplate(ex);
			return template.TransformText();
		}

		public static String ToHTML(this String markdown)
		{
			if (markdown == null) return String.Empty;
			var html = Markdown.ToHtml(markdown, Pipeline);
			return html;
		}
	}
}
