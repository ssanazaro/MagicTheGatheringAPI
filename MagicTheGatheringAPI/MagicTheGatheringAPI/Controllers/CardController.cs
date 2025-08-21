using MagicTheGathering.Shared.Models;
using MagicTheGatheringAPI.Managers;
using Microsoft.AspNetCore.Mvc;

namespace MagicTheGatheringAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CardController : ControllerBase
	{
		private readonly IScryfallManager _scryfallManager;

		public CardController(IScryfallManager scryfallManager)
		{
			_scryfallManager = scryfallManager;
		}

		// GET /CardController/card/{cardId}
		[HttpGet("card/{cardId}")]
		public async Task<ActionResult<Card>> GetCardById(string cardId)
		{
			var card = await _scryfallManager.GetCardById(cardId);
			if (card == null) return NotFound();
			return Ok(card);
		}

		// GET /CardController/name/{cardName}
		[HttpGet("name/{cardName}")]
		public async Task<ActionResult<Card>> GetCardByName(string cardName)
		{
			var card = await _scryfallManager.GetCardByName(cardName);
			if (card == null) return NotFound();
			return Ok(card);
		}

		// POST /CardController/batch-names
		// Body: ["Black Lotus", "Counterspell", "Llanowar Elves"]
		[HttpPost("batch-names")]
		public async Task<ActionResult<List<Card>>> GetCardsByNames([FromBody] List<string> names)
		{
			if (names == null || names.Count == 0)
				return BadRequest("No card names provided.");

			var cards = await _scryfallManager.GetCardsByNames(names);
			return Ok(cards);
		}

		// POST /CardController/deck
		// Body: { "cards": ["Black Lotus", "Counterspell", ...] }
		[HttpPost("deck")]
		public async Task<ActionResult<List<Card>>> LoadDeck([FromBody] DeckRequest deckRequest)
		{
			if (deckRequest?.Cards == null || deckRequest.Cards.Count == 0)
				return BadRequest("No cards in deck.");

			var cards = await _scryfallManager.GetCardsByNames(deckRequest.Cards);
			return Ok(cards);
		}

		// GET /CardController/name/{cardName}
		[HttpGet("search")]
		public async Task<ActionResult<Card>> GetCardsByCustomSearch(string format, string color)
		{
			var card = await _scryfallManager.GetCardsByCustomeSearch(format, color);
			if (card == null) return NotFound();
			return Ok(card);
		}
	}

	// DTO for deck loading
	public class DeckRequest
	{
		public List<string> Cards { get; set; } = new();
	}
}
