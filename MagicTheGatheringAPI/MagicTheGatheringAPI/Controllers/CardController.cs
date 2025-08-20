using MagicTheGathering.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MagicTheGatheringAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CardController : ControllerBase
	{
		private readonly HttpClient _client;
		private readonly JsonSerializerOptions _jsonOptions;

		public CardController(HttpClient client)
		{
			_client = client;

			// Required headers for Scryfall
			_client.DefaultRequestHeaders.Clear();
			_client.DefaultRequestHeaders.Add("User-Agent", "MagicTheGatheringAPI/1.0 test@yahoo.com)");
			_client.DefaultRequestHeaders.Add("Accept", "application/json");

			_jsonOptions = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};
		}

		// GET /CardController/card/{cardId}
		[HttpGet("card/{cardId}")]
		public async Task<ActionResult<Card>> GetCardById(string cardId)
		{
			var response = await _client.GetAsync($"https://api.scryfall.com/cards/{cardId}");

			if (!response.IsSuccessStatusCode)
				return NotFound();

			var stream = await response.Content.ReadAsStreamAsync();
			var card = await JsonSerializer.DeserializeAsync<Card>(stream, _jsonOptions);

			return card != null ? Ok(card) : BadRequest("Unable to parse card data.");
		}


		// GET /CardController/name/{cardName}
		[HttpGet("name/{cardName}")]
		public async Task<ActionResult<Card>> GetCardByName(string cardName)
		{
			var response = await _client.GetAsync($"https://api.scryfall.com/cards/named?fuzzy={cardName}");

			if (!response.IsSuccessStatusCode)
				return NotFound();

			var stream = await response.Content.ReadAsStreamAsync();
			var card = await JsonSerializer.DeserializeAsync<Card>(stream, _jsonOptions);

			return card != null ? Ok(card) : BadRequest("Unable to parse card data.");
		}
	}
}
