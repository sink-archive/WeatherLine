using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeatherLine
{
	internal static class Program
	{
		private static async Task Main()
		{
			var loc     = await GetLocation();
			var weather = await MetaWeather.GetWeather(loc);
		}

		private static async Task<MetaWeather.Location> GetLocation()
		{
			var configPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
										  "weatherline.conf.json");
			
			MetaWeather.Location loc;
			if (!File.Exists(configPath))
				loc = await PickLocation();
			else
				loc = JsonSerializer.Deserialize<Config>(await File.ReadAllTextAsync(configPath))?.Loc ?? await PickLocation();

			await File.WriteAllTextAsync(configPath, JsonSerializer.Serialize(new Config { Loc = loc }));
			return loc;
		}

		private static async Task<MetaWeather.Location> PickLocation()
		{
			while (true)
			{
				Console.Write("Please search for your location >>> ");
				var search        = Console.ReadLine();
				var searchResults = await MetaWeather.GetLocations(search);
				
				for (var i = 0; i < searchResults.Length; i++)
					Console.WriteLine($"{i}: {searchResults[i]}");
				
				Console.Write("Pick from the options, or choose none to search again >>> ");
				var choice = Console.ReadLine();
				if (int.TryParse(choice, out var intChoice) && intChoice >= 0 && intChoice < searchResults.Length)
				{
					return searchResults[intChoice];
				}
			}
		}
	}
}