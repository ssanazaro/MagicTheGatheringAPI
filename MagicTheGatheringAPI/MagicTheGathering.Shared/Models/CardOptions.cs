using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTheGathering.Shared.Models
{
	public static class CardOptions
	{
		public static readonly List<(string Value, string Display)> Formats = new()
	{
		("standard", "Standard"),
		("future", "Future"),
		("historic", "Historic"),
		("timeless", "Timeless"),
		("gladiator", "Gladiator"),
		("pioneer", "Pioneer"),
		("modern", "Modern"),
		("legacy", "Legacy"),
		("pauper", "Pauper"),
		("vintage", "Vintage"),
		("penny", "Penny"),
		("commander", "Commander"),
		("oathbreaker", "Oathbreaker"),
		("standardbrawl", "Standard Brawl"),
		("brawl", "Brawl"),
		("alchemy", "Alchemy"),
		("paupercommander", "Pauper Commander"),
		("duel", "Duel"),
		("oldschool", "Old School"),
		("premodern", "Premodern"),
		("predh", "Predh")
	};

		public static readonly List<(string Value, string Display)> Colors = new()
	{
		("B", "Black"),
		("U", "Blue"),
		("G", "Green"),
		("R", "Red"),
		("W", "White")
	};
	}
}
