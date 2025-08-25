using MagicTheGathering.Shared.Models;
using MagicTheGatheringAPI.Services;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;

public class ScryfallService : IScryfallService
{
	private readonly HttpClient _client;
	private readonly JsonSerializerOptions _jsonOptions;
	private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

	// Only one _lastRequest, static so it's shared across all instances
	private static DateTime _lastRequest = DateTime.MinValue;
	private static readonly TimeSpan MinDelay = TimeSpan.FromMilliseconds(50);

	public ScryfallService(HttpClient client)
	{
		_client = client;

		_client.DefaultRequestHeaders.Clear();
		_client.DefaultRequestHeaders.Add("User-Agent", "MagicTheGatheringAPI/1.0 (s.sanazaro91@yahoo.com)");
		_client.DefaultRequestHeaders.Add("Accept", "application/json");

		_jsonOptions = new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true
		};
	}

	private async Task<T?> GetFromScryfall<T>(string url)
	{
		await _semaphore.WaitAsync();
		try
		{
			var timeSinceLast = DateTime.UtcNow - _lastRequest;
			if (timeSinceLast < MinDelay)
				await Task.Delay(MinDelay - timeSinceLast);

			try
			{
				// This can throw if the HTTP response is not successful
				var result = await _client.GetFromJsonAsync<T>(url, _jsonOptions);
				_lastRequest = DateTime.UtcNow;
				return result;
			}
			catch (HttpRequestException)
			{
				// Failed request (network or non-success status code)
				_lastRequest = DateTime.UtcNow;
				return default; // or null
			}
			catch (NotSupportedException)
			{
				// Invalid content type
				_lastRequest = DateTime.UtcNow;
				return default;
			}
			catch (JsonException)
			{
				// Invalid JSON
				_lastRequest = DateTime.UtcNow;
				return default;
			}
		}
		finally
		{
			_semaphore.Release();
		}
	}


	public Task<Card?> GetCardByName(string name)
		=> GetFromScryfall<Card>($"cards/named?fuzzy={Uri.EscapeDataString(name)}");

	public Task<Card?> GetCardById(string id)
		=> GetFromScryfall<Card>($"cards/{id}");

	public async Task<PagedResult<Card>> GetCardsByCustomSearch(string format, string color)
	{
		var response = await GetFromScryfall<ScryfallListResponse<Card>>(
			$"cards/search?q=legal:{format}+color:{color}"
		);

		return response != null
	? new PagedResult<Card>
	{
		Data = response.Data,
		HasMore = response.HasMore,
		NextPageUrl = response.NextPage
	}
	: new PagedResult<Card>();

	}

}
