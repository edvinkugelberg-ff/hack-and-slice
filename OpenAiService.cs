using System.Text;
using Newtonsoft.Json;

namespace HackAndSlice;

public class OpenAiService
	{
		private static HttpClient _httpClient;
		private string ApiKey = "";

		public OpenAiService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<string> GenerateImage(string imagePrompt)
		{
			var content = new ImagePrompt
			{
				prompt = imagePrompt,
				n = 1,
				size = "256x256"
			};

			var jsonBody = JsonConvert.SerializeObject(content);
			var body = new StringContent(jsonBody, Encoding.UTF8, "application/json");
			var url = "https://api.openai.com/v1/images/generations";
			_httpClient.DefaultRequestHeaders.Add("Authorization", $"BEARER {ApiKey}");

			var response = await _httpClient.PostAsync(url, body);
			var result = await response.Content.ReadAsStringAsync();
			var parsedResult = JsonConvert.DeserializeObject<OpenApiImageReponse>(result);

			return parsedResult.Data[0].url;
		}
		
		private class ImagePrompt
		{
			public string prompt { get; set; }
			public int n { get; set; }
			public string size { get; set; }
		}
		
		private class OpenApiImageReponse
		{
			public int Created { get; set; }
			public List<Url> Data { get; set; }
		}

		private class Url
		{
			public string url { get; set; }
		}
	}