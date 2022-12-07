using System.Diagnostics.SymbolStore;
using Newtonsoft.Json;

namespace HackAndSlice;

public class KrisinformationService
{
	private HttpClient _httpClient;
	
	public KrisinformationService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<List<News>> GetNews(string language = "sv", int noOfDaysToFetch = 5)
	{
		var url = $"http://api.krisinformation.se/v3/news?language={language}&days={noOfDaysToFetch}";
		var response = await _httpClient.GetAsync(url);
		var result = await response.Content.ReadAsStringAsync();

		var parsedResult = JsonConvert.DeserializeObject<List<News>>(result);

		return parsedResult;
	}
}

public class News
{
	public string Identifier { get; set; }
	public string PushMessage { get; set; }
	public DateTime Updated { get; set; }
	public DateTime Published { get; set; }
	public string Headline { get; set; }
	public string Preamble { get; set; }
	public string BodyText { get; set; }
	public string ImageLink { get; set; }
	public List<object> Links { get; set; }
	public List<Area> Area { get; set; }
	public string Web { get; set; }
	public string Language { get; set; }
	public string Event { get; set; }
	public string SenderName { get; set; }
	public bool Push { get; set; }
	public List<BodyLink> BodyLinks { get; set; }
	public int SourceID { get; set; }
}

public class Area
{
	public string Type { get; set; }
	public string Description { get; set; }
	public string Coordinate { get; set; }
	public CoordinateObject CoordinateObject { get; set; }
	public object GeometryInformation { get; set; }
}

public class BodyLink
{
	public string Text { get; set; }
	public string Url { get; set; }
}

public class CoordinateObject
{
	public string Latitude { get; set; }
	public string Longitude { get; set; }
	public string Altitude { get; set; }
}



