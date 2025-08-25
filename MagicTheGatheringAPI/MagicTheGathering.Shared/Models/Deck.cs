using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTheGathering.Shared.Models
{
	public class Deck
	{
		public string Name { get; set; } = "My Deck";
		public List<Card> Cards { get; set; } = new();
	}

}
