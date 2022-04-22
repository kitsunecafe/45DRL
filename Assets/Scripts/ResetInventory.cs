using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace JuniperJackal.Entity
{
	public class ResetInventory : MonoBehaviour
	{
		public InventoryReference inventory;

		private void OnEnable()
		{
			inventory.Value.Clear();
		}
	}
}
