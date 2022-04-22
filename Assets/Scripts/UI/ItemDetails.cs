using System.Linq;
using System.Text;
using JuniperJackal.Entity;
using JuniperJackal.Extensions;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace JuniperJackal.UI
{
	public class ItemDetails : Window
	{
		[SerializeField] private InventoryReference inventory;
		[SerializeField] private ItemDrop itemDrop;
		[SerializeField] private UnityEvent<Sprite> spriteSet;
		[SerializeField] private UnityEvent<string> nameSet;
		[SerializeField] private UnityEvent<string> descriptionSet;
		[SerializeField] private UnityEvent<string> propertiesSet;

		private Transform target;
		private Item selectedItem;
		private Equipment equipment;

#if UNITY_EDITOR
		private void Reset()
		{
			TryGetComponent(out itemDrop);
		}
#endif

		public void View(Item item)
		{
			if (item != null)
			{
				selectedItem = item;

				eventSystem.SetSelectedGameObject(gameObject);

				Open();

				spriteSet?.Invoke(item.GetSingleAttribute<SpriteAttribute>().Value);
				nameSet?.Invoke(item.GetName());

				var attributes = item.Attributes.Where(attr => !(attr is ItemProperty))
				 	.Where(attr => attr.VisibleInDescription)
					.Select(attr => attr.Description)
					.ToArray();

				var builder = new StringBuilder();

				for (int i = 0; i < attributes.Length; i++)
				{
					builder.AppendLine(attributes[i]);
				}

				descriptionSet?.Invoke(builder.ToString());
				builder.Clear();

				var properties = item.Attributes.OfType<ItemProperty>().Select(attr => attr.Label).ToArray();
				builder.AppendJoin(", ", properties);
				propertiesSet?.Invoke(builder.ToString());
			}
		}

		private bool IsEquipped(Item item)
		{
			return equipment.AllItems.Where(eq => eq == item).Any();
		}

		public void DropSelectedItem()
		{
			itemDrop.DropItem(selectedItem, target.position);

			if (IsEquipped(selectedItem))
			{
				var slot = selectedItem.GetSingleAttribute<EquipmentSlotAttribute>().Value;
				equipment.Unequip(slot);
			}

			inventory.Value.Remove(selectedItem);

			WindowManager.Instance.CloseAll();
		}

		public bool TryEquip(Item item)
		{
			if (!IsEquipped(item))
			{
				var slot = item.GetSingleAttribute<EquipmentSlotAttribute>().Value;
				equipment.Equip(item, slot);
				WindowManager.Instance.CloseAll();
			}

			return true;
		}

		public void EquipSelectedItem()
		{
			TryEquip(selectedItem);
		}

		public void SetTarget(GameObject target)
		{
			if (target != null)
			{
				this.target = target.transform;
				target.TryGetComponent(out equipment);
			}
		}
	}
}
