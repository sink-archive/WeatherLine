using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeatherLine
{
	internal static class Program
	{
		private static string ConfigPath
			=> Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
							"weatherline.conf.json");

		private static async Task Main(string[] args)
		{
			// r for reset?
			if (args.Contains("-r")) File.Delete(ConfigPath);

			var loc     = await GetLocation();
			var weather = await MetaWeather.GetWeather(loc);
			Console.WriteLine("I havent made a nice frontend yet so heres literally all the data in a barely readable format:");
			Console.WriteLine(JsonSerializer.Serialize(weather, new JsonSerializerOptions
			{
				WriteIndented = true
			}));
			
			
		}

		private static async Task<MetaWeather.Location> GetLocation()
		{ MetaWeather.Location loc;
			if (!File.Exists(ConfigPath))
				loc = await PickLocation();
			else
				loc = JsonSerializer.Deserialize<Config>(await File.ReadAllTextAsync(ConfigPath))?.Loc ?? await PickLocation();

			await File.WriteAllTextAsync(ConfigPath, JsonSerializer.Serialize(new Config { Loc = loc }));
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