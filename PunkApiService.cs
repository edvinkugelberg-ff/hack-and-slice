using Newtonsoft.Json;

namespace HackAndSlice;

public class PunkApiService
{
	private HttpClient _httpClient;

	public PunkApiService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<List<Beer>> GetFoodPairing(string foodItem)
	{
		var url = $"https://api.punkapi.com/v2/beers?{foodItem.Replace(' ','_')}";
		var response = await _httpClient.GetAsync(url);
		var result = await response.Content.ReadAsStringAsync();
		var parsedResult = JsonConvert.DeserializeObject<List<Beer>>(result);

		return parsedResult;
	}

    public async Task<Beer> GetRandomBeer()
    {
        var url = $"https://api.punkapi.com/v2/beers/random";
        var response = await _httpClient.GetAsync(url);
        var result = await response.Content.ReadAsStringAsync();
        var parsedResult = JsonConvert.DeserializeObject<List<Beer>>(result);

        return parsedResult.Single();
    }
}

public class Beer
{
    public int id { get; set; }
    public string name { get; set; }
    public string tagline { get; set; }
    public string first_brewed { get; set; }
    public string description { get; set; }
    public string image_url { get; set; }
    public double abv { get; set; }
    public double? ibu { get; set; }
    public int target_fg { get; set; }
    public double target_og { get; set; }
    public int? ebc { get; set; }
    public double? srm { get; set; }
    public double? ph { get; set; }
    public double attenuation_level { get; set; }
    public Volume volume { get; set; }
    public BoilVolume boil_volume { get; set; }
    public Method method { get; set; }
    public Ingredients ingredients { get; set; }
    public List<string> food_pairing { get; set; }
    public string brewers_tips { get; set; }
    public string contributed_by { get; set; }
}

    public class Amount
    {
        public double value { get; set; }
        public string unit { get; set; }
    }

    public class BoilVolume
    {
        public int value { get; set; }
        public string unit { get; set; }
    }

    public class Fermentation
    {
        public Temp temp { get; set; }
    }

    public class Hop
    {
        public string name { get; set; }
        public Amount amount { get; set; }
        public string add { get; set; }
        public string attribute { get; set; }
    }

    public class Ingredients
    {
        public List<Malt> malt { get; set; }
        public List<Hop> hops { get; set; }
        public string yeast { get; set; }
    }

    public class Malt
    {
        public string name { get; set; }
        public Amount amount { get; set; }
    }

    public class MashTemp
    {
        public Temp temp { get; set; }
        public int? duration { get; set; }
    }

    public class Method
    {
        public List<MashTemp> mash_temp { get; set; }
        public Fermentation fermentation { get; set; }
        public string twist { get; set; }
    }

  

    public class Temp
    {
        public int value { get; set; }
        public string unit { get; set; }
    }

    public class Volume
    {
        public int value { get; set; }
        public string unit { get; set; }
    }


