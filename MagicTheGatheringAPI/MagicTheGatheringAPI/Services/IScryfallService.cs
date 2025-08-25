using MagicTheGathering.Shared.Models;

namespace MagicTheGatheringAPI.Services
{
	public interface IScryfallService
	{
		Task<Card?> GetCardByName(string name);
		Task<Card?> GetCardById(string id);
		Task<PagedResult<Card>> GetCardsByCustomSearch(string format, string color);
	}
}
