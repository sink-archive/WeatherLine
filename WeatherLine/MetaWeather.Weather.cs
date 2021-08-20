using System;
using System.Diagnostics;
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
		[DebuggerDisplay("{Title}, {WeatherData.Length} data points, {Sources.Length} sources")]
		public class Weather
		{
			[JsonPropertyName("title")]                public string                Title       { get; set; }
			[JsonPropertyName("time")]                 public DateTime              Time        { get; set; }
			[JsonPropertyName("parent")]               public Location              Parent      { get; set; }
			[JsonPropertyName("sources")]              public Source[]              Sources     { get; set; }
			[JsonPropertyName("consolidated_weather")] public ConsolidatedWeather[] WeatherData { get; set; }
			[JsonPropertyName("timezone_name")]        public string                Timezone    { get; set; }
			[JsonPropertyName("sun_rise")]             public DateTime              Sunrise     { get; set; }
			[JsonPropertyName("sun_set")]              public DateTime              Sunset      { get; set; }
			[JsonPropertyName("location_type")]        public string                Type        { get; set; }
			[JsonPropertyName("latt_long")]            public string                LatLong     { get; set; }

			[JsonIgnore] public float Latitude  => float.Parse(LatLong.Split(',')[0]);
			[JsonIgnore] public float Longitude => float.Parse(LatLong.Split(',')[1]);
		}
	}
}