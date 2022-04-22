using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;

namespace JuniperJackal.Entity
{
	public class CollectableItem : MonoBehaviour, IInteractable
	{
		public Item Item;
		[SerializeField] private InventoryReference inventory;
		[SerializeField] private UnityEvent<Item> Collected;

		public bool Interact()
		{
			inventory.Value.Add(Item);
			Collected?.Invoke(Item);
			return true;
		}
	}
}
