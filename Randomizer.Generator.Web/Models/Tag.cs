namespace Randomizer.Generator.Web.Models
{
	public class Tag
	{
		public String Name { get; set; } = String.Empty;
		public Boolean Selected { get; set; } = false;

		public static implicit operator String(Tag tag) => tag.Name;
		public static implicit operator Tag(String value) => new() { Name = value };
	}
}
