using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace JuniperJackal.Entity
{

	[Serializable]
	public class WeightedRarity : WeightedRandom<Rarity> { }

	[CreateAssetMenu(fileName = "LootTable", menuName = "Roguelike/Loot Table")]
	public class LootTable : ScriptableObject
	{
		[Serializable]
		private class RarityWeight
		{
			public Rarity Rarity;
			public int Weight;
		}

		[SerializeField] private Loot loot;

		[SerializeField] private RarityWeight[] rarities = new RarityWeight[0];
		private WeightedRarity rarityTable = new WeightedRarity();

		private void OnValidate()
		{
			Initialize();
		}

		private void OnEnable()
		{
			Initialize();
		}

		public void Initialize()
		{
			loot?.Initialize();

			for (int i = 0; i < rarities.Length; i++)
			{
				var rarity = rarities[i];
				rarityTable.AddEntry(rarity.Rarity, rarity.Weight);
			}
		}

		public Item[] SelectRandom() => SelectRandom(1);
		public Item[] SelectRandom(int limit)
		{
			if (loot == null)
			{
				return new Item[0];
			}

			var items = new Item[limit];

			for (int i = 0; i < limit; i++)
			{
				var rarity = rarityTable.GetRandom();
				items[i] = loot.GenerateItem(
					Random.Range(rarity.MinimumModifiers, rarity.MaximumModifiers + 1)
				);
			}

			return items;
		}
	}
}
