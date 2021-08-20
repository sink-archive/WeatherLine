using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace WeatherLine
{
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
	public static partial class MetaWeather
	{
		[UsedImplicitly]
		public class Source
		{
			[JsonPropertyName("title")]      public string Title     { get; set; }
			[JsonPropertyName("slug")]       public string Slug      { get; set; }
			[JsonPropertyName("url")]        public string Url       { get; set; }
			[JsonPropertyName("crawl_rate")] public int    CrawlRate { get; set; }
		}
	}
}