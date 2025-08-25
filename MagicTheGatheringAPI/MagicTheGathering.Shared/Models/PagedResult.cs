using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MagicTheGathering.Shared.Models
{
	public class PagedResult<T>
	{
		[JsonPropertyName("data")]
		public List<T> Data { get; set; } = new();

		[JsonPropertyName("hasMore")]
		public bool HasMore { get; set; }

		[JsonPropertyName("nextPageUrl")]
		public string? NextPageUrl { get; set; }
	}
}
