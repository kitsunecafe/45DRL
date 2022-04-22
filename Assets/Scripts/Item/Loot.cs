using System.Collections.Generic;
using System.Linq;
using JuniperJackal.Entity;
using JuniperJackal.Extensions;
using UnityEngine;

namespace JuniperJackal
{
	[CreateAssetMenu(fileName = "Loot", menuName = "Roguelike/Loot")]
	public class Loot : ScriptableObject
	{
		[System.Serializable]
		public class WeightedItem
		{
			public Item Item;
			public float Weight;
		}

		[SerializeField] private List<WeightedItem> itemWeights;
		[SerializeField] private List<Loot> loots;
		private List<Item> items;
		private WeightedRandom<Item> weightedItems = new WeightedRandom<Item>();
		private WeightedRandom<Loot> weightedLoot = new WeightedRandom<Loot>();
		private float weight = 0;
		public float Weight => weight;

		[SerializeField] private List<ItemAttribute> attributes;
		public List<ItemAttribute> Attributes => attributes;

		public void Initialize()
		{
			for (int i = 0; i < loots.Count; i++)
			{
				loots[i].Initialize();
			}

			items = itemWeights.Select(item => item.Item).ToList();
			weightedItems = CalculateItemWeight();
			weightedLoot = CalculateLootWeight();
		}

		private void OnValidate()
		{
			Initialize();
		}

		private void Awake()
		{
			Initialize();
		}

		private void OnEnable()
		{
			Initialize();
		}

		private WeightedRandom<Loot> CalculateLootWeight()
		{
			var weights = new WeightedRandom<Loot>();
			var childWeight = loots.Sum(loot => loot.Weight);
			weight = childWeight + itemWeights.Sum(item => item.Weight);

			for (int i = 0; i < loots.Count; i++)
			{
				var loot = loots[i];
				weights.AddEntry(loot, loot.Weight);
			}

			if (itemWeights.Count > 0)
			{
				weights.AddEntry(this, weight);
			}

			return weights;
		}

		private WeightedRandom<Item> CalculateItemWeight()
		{
			var weights = new WeightedRandom<Item>();

			for (int i = 0; i < itemWeights.Count; i++)
			{
				var item = itemWeights[i];
				weights.AddEntry(item.Item, item.Weight);
			}

			return weights;
		}

		private Item GetRandomItem()
		{
			var prefab = weightedItems.GetRandom();
			return prefab == null ? Item.None : prefab.Clone();
		}

		private ItemAttribute GetRandomAttribute()
		{
			if (attributes.Count > 0)
			{
				var index = Random.Range(0, attributes.Count - 1);
				return Instantiate(attributes[index]);
			}
			else
			{
				return null;
			}
		}

		private List<Item> GetRandomItems(int count)
		{
			return Enumerable.Range(0, count)
				.Select(_ => GetRandomItem())
				.ToList();
		}

		private List<ItemAttribute> GetRandomAttributes(int count)
		{
			return Enumerable.Range(0, count)
				.Select(_ => GetRandomAttribute())
				.OfType<ItemAttribute>()
				.ToList();
		}

		private void CreateName(Item item, List<ItemAttribute> attributes)
		{
			var nameAttr = item.GetSingleAttribute<NameAttribute>();

			var prefixes = attributes.OfType<INamePrefix>().Select(name => name.Prefix).DefaultIfEmpty().Distinct().ToList();
			var suffixes = attributes.OfType<INameSuffix>().Select(name => name.Suffix).DefaultIfEmpty().Distinct().ToList();

			var newName = new List<string>(prefixes.Count + suffixes.Count + 1);

			newName.AddRange(prefixes);
			newName.Add(nameAttr.Value);
			newName.AddRange(suffixes);

			nameAttr.Value = string.Join(' ', newName).Trim();
		}

		public Item GenerateItem(int count)
		{
			var loot = weightedLoot.GetRandom();

			if (this == loot)
			{
				var item = GetRandomItem();
				if (item == Item.None) { return item; }

				var attributes = GetRandomAttributes(count);

				CreateName(item, attributes);

				item.Attributes.AddRange(attributes);

				return item;
			}
			else
			{
				return loot.GenerateItem(count);
			}
		}

		public List<Item> GenerateItems(int count, int minAttributes, int maxAttributes)
		{
			var results = new List<Item>(count);

			for (int i = 0; i < count; i++)
			{
				var item = GenerateItem(Random.Range(minAttributes, maxAttributes));
				if (item != Item.None)
				{
					results.Add(item);
				}
			}

			return results;
		}
	}
}
