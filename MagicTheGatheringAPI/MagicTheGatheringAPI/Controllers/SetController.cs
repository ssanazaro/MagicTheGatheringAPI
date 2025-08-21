using MagicTheGathering.Shared.Models;
using MagicTheGatheringAPI.Managers;
using Microsoft.AspNetCore.Mvc;

namespace MagicTheGatheringAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class SetController : Controller
	{
		private readonly IScryfallManager _scryfallManager;

		public SetController(IScryfallManager scryfallManager)
		{
			_scryfallManager = scryfallManager;
		}

		// GET /CardController/card/{cardId}
		[HttpGet("card/{cardId}")]
		public async Task<ActionResult<Card>> GetSets(string cardId)
		{
			var card = await _scryfallManager.GetCardById(cardId);
			if (card == null) return NotFound();
			return Ok(card);
		}
	}
}
