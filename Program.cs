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

// var estimatedCarbonOutput = await carbonService.GetCarbonInfo("www.forefront.se"); // NOTE: very very slow
var urlToGeneratedImage = await aiService.GenerateImage("Genius coders at the office not doing any actual work");
var thingToDo = await boredApi.GetThingToDo(1, 1);
var approximateAge = await ageService.GetAge("Edvin", "SE");
var bullshit = await bsService.GetBS();
var beerPairings = await beerService.GetFoodPairing("fish tacos");
var randomBeer = await beerService.GetRandomBeer();
var triviaQuestions = await triviaService.GenerateQuestions();
var reservesInUmea = await reservesService.GetReserves(10);

Console.WriteLine("Would you rather do something else? Try " + thingToDo.activity);
Console.WriteLine("Ever wondered how old the average 'Edvin' is in sweden? Answer is: " + approximateAge);
Console.WriteLine("Want a good excuse to do something cool at work? Try adding this work when you talk to management: " + bullshit);
Console.WriteLine("Want a beer that pairs well with fish tacos? Here is one: "+ beerPairings[0].name + ". It's kind of like this: " + beerPairings[0].description);
Console.WriteLine("Want to grab a beer? Here is one, but i cant guarantee its good: " + randomBeer.name);
Console.WriteLine("Here is a trivia question for you: " + triviaQuestions[0].question);
Console.WriteLine("Here is a list of some nature reserves in Västerbotten: " + string.Join(", ", reservesInUmea.Select(r => r.fields.namn).ToList()));
Console.WriteLine("If you have managed to configure an API-key, your image is ready to be viewed at this url: " + urlToGeneratedImage);
