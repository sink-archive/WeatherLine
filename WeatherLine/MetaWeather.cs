using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeatherLine
{
	public static partial class MetaWeather
	{
		public static async Task<Location[]> GetLocations(string search)
		{
			var client = new HttpClient();
			var req    = await client.GetAsync($"https://www.metaweather.com/api/location/search/?query={search}");
			var raw    = await req.Content.ReadAsStringAsync();

			return JsonSerializer.Deserialize<Location[]>(raw);
		}

		public static async Task<Weather> GetWeather(int woeid, DateTime? date = null)
		{
			var url = $"https://www.metaweather.com/api/location/{woeid}";
			if (date.HasValue)
				url += $"/{date.Value.Year}/{date.Value.Month}/{date.Value.Day}";
			
			var client = new HttpClient();
			var req    = await client.GetAsync(url);
			var raw    = await req.Content.ReadAsStringAsync();

			var weather = JsonSerializer.Deserialize<Weather>(raw);
			weather!.WeatherData = weather.WeatherData.OrderBy(w => w.ApplicableDate).ToArray();
			return weather;
		}
	}
}