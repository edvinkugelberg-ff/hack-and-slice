// See https://aka.ms/new-console-template for more information

using System.Net;
using System.Threading.Channels;
using HackAndSlice;

var httpClient = new HttpClient();
var aiService = new OpenAiService(httpClient);
var boredApi = new BoredService(httpClient);
var ageService = new AgifyService(httpClient);
var bsService = new CorporateBsService(httpClient);
var carbonService = new WebsiteCarbonService(httpClient);
var beerService = new PunkApiService(httpClient);
var triviaService = new TriviaService(httpClient);
var reservesService = new NaturreservatVasterbottenService(httpClient);
// var thingToDo = await boredApi.GetThingToDo(1, 1);
// var result = await ageService.GetAge("Edvin", "SE");
// var bs = await bsService.GetBS();
// var carbon = await carbonService.GetCarbonInfo("www.forefront.se");
// var foodbeers = await beerService.GetFoodPairing("fish tacos");
// var oneBeer = await beerService.GetRandomBeer();
// var questions = await triviaService.GenerateQuestions();
var reserves = await reservesService.GetReserves(100);
Console.WriteLine(string.Join(',', reserves.Select(r => r.fields.namn).ToList()));
