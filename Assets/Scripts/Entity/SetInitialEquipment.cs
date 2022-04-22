using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace JuniperJackal.Entity
{
	public class SetInitialEquipment : MonoBehaviour
	{
		[System.Serializable]
		public class EquipmentCombination
		{
			public ItemReference EquipmentSlot;
			public Item Item;
		}

		[SerializeField] private EquipmentCombination[] InitialEquipment;

		private void Start()
		{
			Do();
		}

		public void Do()
		{
			foreach (var equipment in InitialEquipment)
			{
				equipment.EquipmentSlot.Value = equipment.Item;
			}
		}
	}
}
