using System.Text.Json.Serialization;

public class ScryfallListResponse<T>
{
	public string Object { get; set; }

	[JsonPropertyName("total_cards")]

	public int TotalCards { get; set; }

	[JsonPropertyName("has_more")]
	public bool HasMore { get; set; }

	[JsonPropertyName("next_page")]
	public string NextPage { get; set; }
	
	[JsonPropertyName("data")]
	public List<T> Data { get; set; }
}
