using System.Diagnostics.SymbolStore;
using Newtonsoft.Json;

namespace HackAndSlice;

public class TriviaService
{
	private HttpClient _httpClient;
	
	public TriviaService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<List<Questions>> GenerateQuestions(int numberOfQuestions = 10)
	{
		var url = $"https://opentdb.com/api.php?amount={numberOfQuestions}";
		var response = await _httpClient.GetAsync(url);
		var result = await response.Content.ReadAsStringAsync();

		var parsedResult = JsonConvert.DeserializeObject<TriviaResult>(result);

		return parsedResult.results;
	}
}

public class TriviaResult
{
	public int response_code { get; set; }
	public List<Questions> results { get; set; }
}


public class Questions
{
	public string category { get; set; }
	public string type { get; set; }
	public string difficulty { get; set; }
	public string question { get; set; }
	public string correct_answer { get; set; }
	public List<string> incorrect_answers { get; set; }
}




