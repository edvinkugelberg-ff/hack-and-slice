using System.Diagnostics.SymbolStore;
using Newtonsoft.Json;

namespace HackAndSlice;

public class BoredService
{
	private HttpClient _httpClient;
	
	public BoredService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<Thing> GetThingToDo(int participants = default, decimal maxPrice = default)
	{
		var url = $"https://www.boredapi.com/api/activity?" +
		          $"{(participants != default ? $"participants={participants}&" : "")}" +
		          $"{(maxPrice != default ? $"maxPrice={maxPrice}" : "")}".Trim('&');
		var response = await _httpClient.GetAsync(url);
		var result = await response.Content.ReadAsStringAsync();

		var parsedResult = JsonConvert.DeserializeObject<Thing>(result);

		return parsedResult;
	}
}


public class Thing
{
	public string activity { get; set; }
	public string type { get; set; }
	public int participants { get; set; }
	public double price { get; set; }
	public string link { get; set; }
	public string key { get; set; }
	public double accessibility { get; set; }
}




