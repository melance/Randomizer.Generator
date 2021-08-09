using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Utility
{
	public class UtilityMethods
	{
		public static string HTMLToText(string html)
		{
			if (string.IsNullOrEmpty(html)) return string.Empty;

			var document = new HtmlDocument();
			document.LoadHtml(html);

			var nodes = new Queue<HtmlNode>(document.DocumentNode.SelectNodes("./*|./text()"));
			while (nodes.Count > 0)
			{
				var node = nodes.Dequeue();
				var parentNode = node.ParentNode;

				if (node.Name != "#text")
				{
					var childNodes = node.SelectNodes("./*|./text()");

					if (childNodes != null)
					{
						foreach (var child in childNodes)
						{
							nodes.Enqueue(child);
							parentNode.InsertBefore(child, node);
						}
					}
					parentNode.RemoveChild(node);
				}
			}

			return document.DocumentNode.InnerHtml;
		}
	}
}
