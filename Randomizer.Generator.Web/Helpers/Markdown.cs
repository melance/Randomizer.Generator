using Markdig;

namespace Randomizer.Generator.Web.Helpers
{
	public static class Markdown
	{
		private static MarkdownPipeline Pipeline { get; } = new MarkdownPipelineBuilder()
															   .UseAdvancedExtensions()
															   .UseAutoIdentifiers()
															   .UseBootstrap()
															   .Build();

		public static String ToHtml(this String markdown)
		{
			if (markdown == null) return String.Empty;
			var html = Markdig.Markdown.ToHtml(markdown, Pipeline);
			return html;
		}
	}
}
