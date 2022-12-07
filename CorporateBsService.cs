using Newtonsoft.Json;

namespace HackAndSlice;

public class CorporateBsService
{
	private HttpClient _httpClient;

	public CorporateBsService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<string> GetBS()
	{
		var url = $"https://corporatebs-generator.sameerkumar.website/";
		var response = await _httpClient.GetAsync(url);
		var result = await response.Content.ReadAsStringAsync();
		var parsedResult = JsonConvert.DeserializeObject<BS>(result);

		return parsedResult.phrase;
	}
}

public class BS
{
	public string phrase { get; set; }
}
