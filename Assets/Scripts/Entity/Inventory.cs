using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using JuniperJackal.Extensions;
using UnityEngine;

namespace JuniperJackal.Entity
{
	[Serializable]
	public class InventoryItem
	{
		public Item Item;
		public int Quantity;

		public InventoryItem(Item item, int quantity)
		{
			Item = item;
			Quantity = quantity;
		}
	}

	[Serializable]
	public class Inventory
	{
		[SerializeField] private List<InventoryItem> items = new List<InventoryItem>();
		private ReadOnlyCollection<InventoryItem> readOnlyItems;
		public ReadOnlyCollection<InventoryItem> Items => readOnlyItems ?? (readOnlyItems = items.AsReadOnly());

		private int MaxStack(Item item)
		{
			return item.GetAttributes<StackableAttribute>().Select(a => a.Value).DefaultIfEmpty(1).First();
		}

		public void Clear()
		{
			items.Clear();
		}

		public void Add(Item item) => Add(item, 1);
		public void Add(Item item, int quantity) => Add(item, quantity, MaxStack(item));
		public void Add(Item item, int quantity, int maxStack)
		{

			var found = items.Find(ii => ii.Item == item && ii.Quantity < maxStack) ?? new InventoryItem(item, 0);

			if (found.Quantity == 0)
			{
				items.Add(found);
			}

			var nextQuantity = found.Quantity + quantity;
			var leftover = Mathf.Max(0, nextQuantity - maxStack);
			found.Quantity = Mathf.Min(nextQuantity, maxStack);

			if (leftover > 0)
			{
				Add(item, leftover);
			}
		}

		private InventoryItem FindOrCreate(Item item)
		{
			return Find(item) ?? new InventoryItem(item, 0);
		}

		public InventoryItem Find(Item item)
		{
			return items.Find(ii => item.Equals(ii.Item));
		}

		private int FindIndex(Item item)
		{
			return items.FindIndex(ii => ii.Item.Equals(item));
		}

		public void Remove(Item item) => Remove(item, 1);
		public void Remove(Item item, int quantity)
		{
			var index = FindIndex(item);
			var found = items[index];

			if (found == null) { return; }

			var diff = found.Quantity - quantity;
			if (diff > 0)
			{
				found.Quantity = diff;
			}
			else
			{
				items.RemoveAt(index);

				if (diff < 0)
				{
					Remove(item, Mathf.Abs(diff));
				}
			}
		}
	}
}
