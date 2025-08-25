using MagicTheGathering.Shared.Models;
using MagicTheGatheringAPI.Managers;
using MagicTheGatheringAPI.Services;
using System.Xml.Linq;

public class ScryfallManager : IScryfallManager
{
	private readonly IScryfallService _scryfallService;

	public ScryfallManager(IScryfallService scryfallService)
	{
		_scryfallService = scryfallService;
	}

	public async Task<Card?> GetCardByName(string name)
	{
		if (string.IsNullOrWhiteSpace(name))
			return null;

		return await _scryfallService.GetCardByName(name);
	}

	public async Task<Card?> GetCardById(string id)
	{
		if (string.IsNullOrWhiteSpace(id))
			return null;

		return await _scryfallService.GetCardById(id);
	}

	public async Task<List<Card>> GetCardsByNames(IEnumerable<string> names)
	{
		var cards = new List<Card>();

		foreach (var name in names)
		{
			var card = await _scryfallService.GetCardByName(name);
			if (card != null)
			{
				cards.Add(card);
			}
		}

		return cards;
	}

	public Task<PagedResult<Card>> GetCardsByCustomeSearch(string format, string color)
	{
		var cards = _scryfallService.GetCardsByCustomSearch(format, color);
		return cards;
	}
}
