using Newtonsoft.Json;

namespace HackAndSlice;

public class NaturreservatVasterbottenService
{
	private HttpClient _httpClient;

	public NaturreservatVasterbottenService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<List<SiteInfo>> GetReserves(int take = 10, int skip = 0)
	{
		var url = $"https://opendata.umea.se/api/v2/catalog/datasets/skyddade-omraden-naturreservat-sverigesweden/records?limit={take}&offset={skip}&include_app_metas=False";
		var response = await _httpClient.GetAsync(url);
		var result = await response.Content.ReadAsStringAsync();
		var parsedResult = JsonConvert.DeserializeObject<ApiResult>(result);

		return parsedResult.records.Select(r => r.record).ToList();
	}
}

public class ApiResult
{
	public int total_count { get; set; }
	public List<Link> links { get; set; }
	public List<Record> records { get; set; }
}

    public class Fields
    {
        public GeoPoint2d geo_point_2d { get; set; }
        public GeoShape geo_shape { get; set; }
        public string nvrid { get; set; }
        public string namn { get; set; }
        public string skyddstyp { get; set; }
        public string beslstatus { get; set; }
        public string ursbesldat { get; set; }
        public object ikraftdatf { get; set; }
        public string ursgalldat { get; set; }
        public string sengalldat { get; set; }
        public object tillsynsmh { get; set; }
        public object provnmhdis { get; set; }
        public object provnmhtil { get; set; }
        public string lan { get; set; }
        public string kommun { get; set; }
        public string iucnkat { get; set; }
        public string forvaltare { get; set; }
        public double area_ha { get; set; }
        public double land_ha { get; set; }
        public double vatten_ha { get; set; }
        public double skog_ha { get; set; }
        public string geostatus { get; set; }
        public string diarienr { get; set; }
        public string lagrum { get; set; }
        public string beslmynd { get; set; }
    }

    public class Geometry
    {
        public List<List<List<double>>> coordinates { get; set; }
        public string type { get; set; }
    }

    public class GeoPoint2d
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class GeoShape
    {
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
    }

    public class Link
    {
        public string rel { get; set; }
        public string href { get; set; }
    }

    public class Properties
    {
    }

    public class Record
    {
        public List<Link> links { get; set; }
        public SiteInfo record { get; set; }
    }

    public class SiteInfo
    {
        public string id { get; set; }
        public DateTime timestamp { get; set; }
        public int size { get; set; }
        public Fields fields { get; set; }
    }




