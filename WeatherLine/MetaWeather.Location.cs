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
		public class Location
		{
			[JsonPropertyName("title")]         public string Title    { get; set; }
			[JsonPropertyName("woeid")]         public int    Woeid    { get; set; }
			[JsonPropertyName("distance")]      public int?   Distance { get; set; }
			[JsonPropertyName("location_type")] public string Type     { get; set; }
			[JsonPropertyName("latt_long")]     public string LatLong  { get; set; }

			[JsonIgnore] public float Latitude  => float.Parse(LatLong.Split(',')[0]);
			[JsonIgnore] public float Longitude => float.Parse(LatLong.Split(',')[1]);

			public override string ToString() => $"{Title} ({Type}) at {Latitude}, {Longitude}";
			
			public static implicit operator int(Location loc) => loc.Woeid;
		}
	}
}