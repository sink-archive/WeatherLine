using System;
using System.Diagnostics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace WeatherLine
{
	public static partial class MetaWeather
	{
		[UsedImplicitly]
		[DebuggerDisplay("{Id}: {WeatherState} - {Temp}°C ({Agreement}% agreed}")]
		public class ConsolidatedWeather
		{
			[JsonPropertyName("id")]                     public long     Id                  { get; set; }
			[JsonPropertyName("applicable_date")]        public DateTime ApplicableDate      { get; set; }
			[JsonPropertyName("wind_speed")]             public float    WindSpeed           { get; set; }
			[JsonPropertyName("wind_direction")]         public float    WindDirection       { get; set; }
			[JsonPropertyName("wind_direction_compass")] public string   WindCompass         { get; set; }
			[JsonPropertyName("air_pressure")]           public float    AirPressure         { get; set; }
			[JsonPropertyName("humidity")]               public float    Humidity            { get; set; }
			[JsonPropertyName("visibility")]             public float    Visibility          { get; set; }
			[JsonPropertyName("predictability")]         public int      Agreement           { get; set; }
			[JsonPropertyName("weather_state_name")]     public string   WeatherState        { get; set; }
			[JsonPropertyName("weather_state_abbr")]     public string   WeatherAbbreviation { get; set; }
			[JsonPropertyName("min_temp")]               public float    Low                 { get; set; }
			[JsonPropertyName("max_temp")]               public float    High                { get; set; }
			[JsonPropertyName("the_temp")]               public float    Temp                { get; set; }
		}
	}
}