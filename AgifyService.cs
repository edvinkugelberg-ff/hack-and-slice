using Newtonsoft.Json;

namespace HackAndSlice;

public class AgifyService
{
	private HttpClient _httpClient;

	public AgifyService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="name"></param>
	/// <param name="countryId"></param>
	/// <remarks> Country id can have any of the following values: Afghanistan, AF. Albania, AL. Algeri, DZ. American Samoa, AS. Andorra, AD. Angola, AO. Anguilla, AI. Antarctic, AQ. Antigua and Barbuda, AG. Argentina, AR. Armenia, AM. Aruba, AW. Australia, AU. Austria, AT. Azerbaija, AZ. Bahamas, BS. Bahrain, BH. Bangladesh, BD. Barbado, BB. Belarus, BY. Belgiu, BE. Belize, BZ. Benin, BJ. Bermud, BM. Bhutan, BT. Bolivia, BO. Bosnia and Herzegovina, BA. Botswana, BW. Bouvet Islan, BV. Brazil, BR. British Indian Ocean Territor, IO. British Virgin Island, VG. Brunei, BN. Bulgaria, BG. Burkina Faso, BF. Burundi, BI. Cambodia, KH. Cameroon, CM. Canada, CA. Cape Verde, CV. Cayman Island, KY. Central African Republic, CF. Chad, TD. Chile, CL. China, CN. Christmas Islan, CX. Cocos Island, CC. Colombia, CO. Comoros, KM. Cook Island, CK. Costa Rica, CR. Croatia, HR. Cuba, CU. Cyprus, CY. Czech Republi, CZ. Democratic Republic of the Congo, CD. Denmark, DK. Djibouti, DJ. Dominic, DM. Dominican Republic, DO. East Timor, TL. Ecuador, EC. Egypt, EG. El Salvador, SV. Equatorial Guinea, GQ. Eritre, ER. Estonia, EE. Ethiopia, ET. Falkland Island, FK. Faroe Islands, FO. Fiji, FJ. Finland, FI. Franc, FR. French Guiana, GF. French Polynesia, PF. Gabon, GA. Gambia, GM. Georgia, GE. German, DE. Ghana, GH. Gibraltar, GI. Greece, GR. Greenland, GL. Grenad, GD. Gua, GU. Guadeloupe, GP. Guatemala, GT. Guernsey, GG. Guinea-Bissau, GW. Guinea, GN. Guyan, GY. Haiti, HT. Honduras, HN. Hong Kong, HK. Hungar, HU. Iceland, IS. India, IN. Indonesi, ID. Iran, IR. Iraq, IQ. Ireland, IE. Isle of Man, IM. Israel, IL. Ital, IT. Ivory Coast, CI. Jamaica, JM. Japan, JP. Jersey, JE. Jordan, JO. Kazakhstan, KZ. Kenya, KE. Kiribat, KI. Kuwait, KW. Kyrgyzstan, KG. Laos, LA. Latvia, LV. Lebanon, LB. Lesotho, LS. Liberia, LR. Libya, LY. Liechtenstein, LI. Lithuania, LT. Luxembourg, LU. Maca, MO. Macedonia, MK. Madagascar, MG. Malawi, MW. Malaysia, MY. Maldives, MV. Mali, ML. Malta, MT. Marshall Island, MH. Martinique, MQ. Mauritania, MR. Mauritius, MU. Mayotte, YT. Mexico, MX. Micronesi, FM. Moldova, MD. Monaco, MC. Mongolia, MN. Montenegro, ME. Montserra, MS. Morocc, MA. Mozambique, MZ. Myanmar, MM. Namibia, NA. Naur, NR. Nepal, NP. Netherland, NL. Netherlands Antille, AN. New Caledonia, NC. New Zealand, NZ. Nicaragua, NI. Niger, NE. Nigeri, NG. Niu, NU. Norfolk Islan, NF. North Kore, KP. Northern Mariana Islands, MP. Norway, NO. Oman, OM. Pakistan, PK. Palau, PW. Palestin, PS. Panama, PA. Papua New Guine, PG. Paraguay, PY. Peru, PE. Philippine, PH. Pitcair, PN. Polan, PL. Portuga, PT. Puerto Rico, PR. Qatar, QA. Republic of the Congo, CG. Reunion, RE. Romani, RO. Russi, RU. Rwanda, RW. Saint Barthelem, BL. Saint Helena, SH. Saint Kitts and Nevi, KN. Saint Luci, LC. Saint Marti, MF. Saint Pierre and Miquelo, PM. Saint Vincent and the Grenadine, VC. Samo, WS. San Marino, SM. Sao Tome and Principe, ST. Saudi Arabia, SA. Senegal, SN. Serbia, RS. Seychelles, SC. Sierra Leone, SL. Singapore, SG. Slovakia, SK. Slovenia, SI. Solomon Island, SB. Somalia, SO. South Africa, ZA. South Georgia And Sandwich Isl, GS. South Korea, KR. Spai, ES. Sri Lanka, LK. Sudan, SD. Surinam, SR. Svalbard and Jan Maye, SJ. Swaziland, SZ. Swede, SE. Switzerlan, CH. Syria, SY. Taiwan, TW. Tajikistan, TJ. Tanzania, TZ. Thailan, TH. Togo, TG. Tokela, TK. Tong, TO. Trinidad and Tobago, TT. Tunisia, TN. Turke, TR. Turkmenistan, TM. Turks and Caicos Island, TC. Tuval, TV. U.S. Virgin Island, VI. Uganda, UG. Ukraine, UA. United Arab Emirates, AE. United Kingdo, GB. United State, US. Uruguay, UY. Uzbekistan, UZ. Vanuat, VU. Vatica, VA. Venezuela, VE. Vietnam, VN. Wallis and Futun, WF. Western Sahara, EH. Yemen, YE. Zambia, ZM. Zimbabwe, ZW </remarks>
	/// <returns></returns>
	public async Task<int> GetAge(string name, string countryId = "")
	{
		var url = $"https://api.agify.io?name={name}" +
		          $"{(countryId != "" ? $"&country_id={countryId}" : "")}";
		var response = await _httpClient.GetAsync(url);
		var result = await response.Content.ReadAsStringAsync();

		var parsedResult = JsonConvert.DeserializeObject<AgeResult>(result);

		return parsedResult.age;
	}
}

public class AgeResult
{
	public int age { get; set; }
	public int count { get; set; }
	public string name { get; set; }
}
