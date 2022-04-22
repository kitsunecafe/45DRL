using System.Linq;
using JuniperJackal.Entity;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;

namespace JuniperJackal
{
	public class TreasureChest : MonoBehaviour, IInteractable
	{
		[SerializeField] private LootTable lootTable;
		[SerializeField] private InventoryReference inventory;
		[SerializeField] private UnityEvent<Item> Collected;

		public bool Interact()
		{
			var item = lootTable.SelectRandom().First();

			var gotItem = item != Item.None;

			if (gotItem)
			{
				inventory.Value.Add(item);
			}

			Collected?.Invoke(item);

			return gotItem;
		}
	}
}
