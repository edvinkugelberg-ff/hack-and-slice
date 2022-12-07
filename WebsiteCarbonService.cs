using Newtonsoft.Json;

namespace HackAndSlice;

public class WebsiteCarbonService
{
	private HttpClient _httpClient;

	public WebsiteCarbonService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<CarbonInfo> GetCarbonInfo(string siteUrl)
	{
		var url = $"https://api.websitecarbon.com/site?url={siteUrl}";
		var response = await _httpClient.GetAsync(url);
		var result = await response.Content.ReadAsStringAsync();
		var parsedResult = JsonConvert.DeserializeObject<CarbonInfo>(result);

		return parsedResult;
	}
}

public class CarbonInfo
{
	public string url { get; set; }
	public bool green { get; set; }
	public int bytes { get; set; }
	public double cleanerThan { get; set; }
	public Statistics statistics { get; set; }
	public int timestamp { get; set; }
}

public class Co2
{
	public Grid grid { get; set; }
	public Renewable renewable { get; set; }
}

public class Grid
{
	public double grams { get; set; }
	public double litres { get; set; }
}

public class Renewable
{
	public double grams { get; set; }
	public double litres { get; set; }
}

public class Statistics
{
	public double adjustedBytes { get; set; }
	public double energy { get; set; }
	public Co2 co2 { get; set; }
}


