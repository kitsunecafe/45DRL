using System.Collections.Generic;
using System.Linq;
using JuniperJackal.Extensions;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace JuniperJackal.Entity
{
	public enum EquipmentSlot
	{
		MainHand,
		OffHand,
		Helmet,
		Armor,
		Accessory1,
		Accessory2
	}


	public class Equipment : MonoBehaviour
	{
		public static readonly Dice UnarmedDamage = new Dice(1, 1);

		[SerializeField] private InventoryReference inventory;

		[SerializeField] private ItemReference mainHand;
		public Item MainHand => mainHand.Value;
		[SerializeField] private ItemReference offHand;
		public Item OffHand => offHand.Value;
		[SerializeField] private ItemReference helmet;
		public Item Helmet => helmet.Value;
		[SerializeField] private ItemReference armor;
		public Item Armor => armor.Value;
		[SerializeField] private ItemReference accessory1;
		public Item Accessory1 => accessory1.Value;
		[SerializeField] private ItemReference accessory2;
		public Item Accessory2 => accessory2.Value;

		private IEnumerable<ItemReference> allItemReferences => new ItemReference[] { mainHand, offHand, helmet, armor, accessory1, accessory2 };
		public IEnumerable<Item> AllItems => new Item[] { MainHand, OffHand, Helmet, Armor, Accessory1, Accessory2 };
		public IEnumerable<Item> Weapons => AllItems.Where(item => item.HasAttribute<DamageAttribute>());

		public void Clear()
		{
			foreach (var itemRef in allItemReferences)
			{
				itemRef.Value = null;
			}
		}

		private ItemReference GetSlotItemReference(EquipmentSlot slot)
		{
			switch (slot)
			{
				case EquipmentSlot.MainHand: return mainHand;
				case EquipmentSlot.OffHand: return offHand;
				case EquipmentSlot.Helmet: return helmet;
				case EquipmentSlot.Armor: return armor;
				case EquipmentSlot.Accessory1: return accessory1;
				case EquipmentSlot.Accessory2: return accessory2;
				default: return null;
			}
		}

		private Item GetSlotItem(EquipmentSlot slot)
		{
			return GetSlotItemReference(slot)?.Value;
		}

		private bool IsEmpty(EquipmentSlot slot)
		{
			return GetSlotItem(slot) == null;
		}

		private void SetSlotItem(Item item, EquipmentSlot slot)
		{
			var itemRef = GetSlotItemReference(slot);

			if (itemRef != null)
			{
				itemRef.Value = item;
			}
		}

		public void Unequip(EquipmentSlot slot)
		{
			if (!IsEmpty(slot))
			{
				var item = GetSlotItem(slot);
				item.ReceiveMessage<UnequipMessage>(new UnequipMessage(this));
				SetSlotItem(null, slot);
				inventory.Value.Add(item);
			}
		}

		private static bool ValidateSlot(Item item, EquipmentSlot slot)
		{
			return item.GetAttributes<EquipmentSlotAttribute>().Where(a => a.Value == slot).Any();
		}

		public bool Equip(Item item, EquipmentSlot slot)
		{
			bool canEquip = inventory.Value.Find(item).Quantity > 0 && ValidateSlot(item, slot);

			if (canEquip)
			{
				Unequip(slot);

				inventory.Value.Remove(item);
				item.ReceiveMessage<EquipMessage>(new EquipMessage(this));
				SetSlotItem(item, slot);

				if (item.HasProperty<TwoHandedProperty>())
				{
					SetSlotItem(null, EquipmentSlot.OffHand);
				}
			}

			return canEquip;
		}

		public int RollForDamage()
		{
			return AllItems.Select(RollItemDamage).Sum();
		}

		public static IEnumerable<Dice> GatherDice(Item item)
		{
			return item?.Attributes?.OfType<DamageAttribute>()
			.Select(damage => damage.Dice)
			.DefaultIfEmpty(UnarmedDamage);
		}

		public int CurrentArmorClass()
		{
			return AllItems.Select(CalculateItemArmorClass).Sum();
		}

		public int RollItemDamage(Item item)
		{
			if (item == null) { return 0; }

			var dice = GatherDice(item).ToList();

			if (item.HasProperty<VersatileProperty>() && IsEmpty(EquipmentSlot.OffHand))
			{
				dice.Add(VersatileProperty.Value);
			}

			return Dice.Roll(dice);
		}

		public static int CalculateItemArmorClass(Item item)
		{
			return SumIntAttribute<ArmorClassAttribute>(item);
		}

		public static int SumIntAttribute<T>(Item item) where T : IntAttribute
		{
			return item?.Attributes?.OfType<T>()
				.Select(attr => attr.Value)
				.DefaultIfEmpty(0)
				.Sum() ?? 0;
		}
	}
}
