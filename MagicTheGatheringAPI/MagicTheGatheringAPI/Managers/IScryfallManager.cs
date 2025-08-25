using MagicTheGathering.Shared.Models;

namespace MagicTheGatheringAPI.Managers
{
	public interface IScryfallManager
	{
		Task<Card?> GetCardByName(string name);
		Task<Card?> GetCardById(string id);
		Task<List<Card>> GetCardsByNames(IEnumerable<string> names);
		Task<PagedResult<Card>> GetCardsByCustomeSearch(string format, string color);
	}
}
