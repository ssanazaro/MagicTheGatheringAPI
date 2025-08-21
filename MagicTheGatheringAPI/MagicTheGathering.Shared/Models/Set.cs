using System;
using System.Text.Json.Serialization;

namespace MagicTheGathering.Shared.Models
{
	public class Set
	{
		[JsonPropertyName("object")]
		public string ObjectType { get; set; } = "set";

		[JsonPropertyName("id")]
		public Guid Id { get; set; }

		[JsonPropertyName("code")]
		public string Code { get; set; } = string.Empty;

		[JsonPropertyName("mtgo_code")]
		public string? MtgoCode { get; set; }

		[JsonPropertyName("arena_code")]
		public string? ArenaCode { get; set; }

		[JsonPropertyName("tcgplayer_id")]
		public int? TcgplayerId { get; set; }

		[JsonPropertyName("name")]
		public string Name { get; set; } = string.Empty;

		[JsonPropertyName("set_type")]
		public string SetType { get; set; } = string.Empty;

		[JsonPropertyName("released_at")]
		public DateTime? ReleasedAt { get; set; }

		[JsonPropertyName("block_code")]
		public string? BlockCode { get; set; }

		[JsonPropertyName("block")]
		public string? Block { get; set; }

		[JsonPropertyName("parent_set_code")]
		public string? ParentSetCode { get; set; }

		[JsonPropertyName("card_count")]
		public int CardCount { get; set; }

		[JsonPropertyName("printed_size")]
		public int? PrintedSize { get; set; }

		[JsonPropertyName("digital")]
		public bool Digital { get; set; }

		[JsonPropertyName("foil_only")]
		public bool FoilOnly { get; set; }

		[JsonPropertyName("nonfoil_only")]
		public bool NonfoilOnly { get; set; }

		[JsonPropertyName("scryfall_uri")]
		public string ScryfallUri { get; set; } = string.Empty;

		[JsonPropertyName("uri")]
		public string Uri { get; set; } = string.Empty;

		[JsonPropertyName("icon_svg_uri")]
		public string IconSvgUri { get; set; } = string.Empty;

		[JsonPropertyName("search_uri")]
		public string SearchUri { get; set; } = string.Empty;
	}
}
