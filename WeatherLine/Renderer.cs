using System;
using System.Text;

namespace WeatherLine
{
	public static class Renderer
	{
		public static string Render(this MetaWeather.ConsolidatedWeather weather)
		{
			var sb = new StringBuilder();

			sb.AppendSeparator($"{Icon(weather.WeatherAbbreviation)} {weather.WeatherState}");
			
			if (weather.Temp.HasValue)
				sb.AppendSeparator($"🌡 {Math.Round(weather.Temp.Value, 1)}°C / {Math.Round(1.8 * weather.Temp.Value + 32, 1)}°F");
			
			if (weather.High.HasValue && weather.Low.HasValue)
				sb.AppendSeparator($"↓ {Math.Round(weather.Low.Value, 1)}°C ↑ {Math.Round(weather.High.Value, 1)}°C");
			
			if (weather.Visibility.HasValue)
				sb.AppendSeparator($"👁 {Math.Round(weather.Visibility.Value, 1)}mi");

			if (weather.WindSpeed.HasValue)
				sb.AppendSeparator($"💨 {Math.Round(weather.WindSpeed.Value, 1)}mph 🧭 {weather.WindCompass}");
				
				
			return sb.ToString();
		}

		public static void AppendSeparator(this StringBuilder sb) => sb.Append("    ");

		public static void AppendSeparator(this StringBuilder sb, string str)
		{
			sb.Append(str); 
			sb.AppendSeparator();
		}

		public static string Icon(string abbr) 
			=> abbr switch
			{
				"sn" => "🌨️",
				"sl" => "🌨️",
				"h"  => "☄️",
				"t"  => "🌩️",
				"hr" => "🌧️",
				"lr" => "🌦️",
				"s"  => "💧",
				"hc" => "☁️",
				"lc" => "⛅️",
				"c"  => "☀️",
				_    => throw new ArgumentOutOfRangeException(nameof(abbr), abbr, null)
			};
		
		public static class Colors
		{
			public const string Black   = "\u001b[30m";
			public const string Red     = "\u001b[31m";
			public const string Green   = "\u001b[32m";
			public const string Yellow  = "\u001b[33m";
			public const string Blue    = "\u001b[34m";
			public const string Magenta = "\u001b[35m";
			public const string Cyan    = "\u001b[36m";
			public const string White   = "\u001b[37m";
		}
	}
}