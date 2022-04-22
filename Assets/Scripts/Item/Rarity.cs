using UnityEngine;

namespace JuniperJackal.Entity
{
	[System.Serializable]
	public class Rarity : Enumeration
	{
		public readonly static Rarity Normal = new Rarity(0, "Normal", 0, 0, Color.white);
		public readonly static Rarity Magic = new Rarity(1, "Magic", 1, 2, Color.blue);
		public readonly static Rarity Rare = new Rarity(2, "Rare", 2, 4, Color.yellow);
		public readonly static Rarity Mythical = new Rarity(3, "Mythical", 3, 5, Color.cyan);

		public int MinimumModifiers = 0;
		public int MaximumModifiers = 0;
		public Color Color = Color.white;

		public Rarity() : this(0, "Normal", 0, 0, Color.white)
		{
		}

		public Rarity(int value, string displayName, int minModifiers, int maxModifiers, Color color) : base(value, displayName)
		{
			MinimumModifiers = minModifiers;
			MaximumModifiers = maxModifiers;
			Color = color;
		}
	}
}
