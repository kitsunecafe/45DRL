using System.Linq;
using JuniperJackal.Entity;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;

namespace JuniperJackal.Procedural
{
	public class LeaveDungeon : ChangeDepth
	{
		[SerializeField] private Item item;
		[SerializeField] private InventoryVariable inventory;

		[SerializeField] private UnityEvent Won;
		[SerializeField] private UnityEvent Lost;

		public override bool Interact()
		{
			if (inventory.Value.Items.Where(ii => ii.Item.ID == item.ID).Any())
			{
				Won?.Invoke();
				return true;
			}
			else
			{
				Lost?.Invoke();
				return false;
			}
		}
	}
}
