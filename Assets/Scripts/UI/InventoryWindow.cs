using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JuniperJackal.Entity;
using JuniperJackal.Extensions;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace JuniperJackal.UI
{
	public class InventoryWindow : Window
	{
		private enum Category
		{
			None,
			Weapon,
			Armor,
			Consumable
		}

		[Serializable]
		private class CategoryObject
		{
			public Category Category;
			public InventoryCategory GameObject;
		}

		[SerializeField] private InventoryReference inventory;
		[SerializeField] private GameObject prefab;
		public GameObject Prefab => prefab;

		[SerializeField] private List<CategoryObject> categories;
		[SerializeField] private UnityEvent<Item> selected;

		private IDictionary<Category, InventoryCategory> categoryObjects = new Dictionary<Category, InventoryCategory>();

		private Equipment equipment;

		private GameObject previouslySelected;

		private void OnValidate()
		{
			categoryObjects.Clear();

			foreach (var category in categories)
			{
				category.GameObject.InventoryWindow = this;
				categoryObjects.Add(category.Category, category.GameObject);
			}
		}

		protected override void Initialize()
		{
			OnValidate();
		}

		private void Cleanup()
		{
			for (int i = 0; i < categories.Count; i++)
			{
				categories[i].GameObject.Clear();
			}
		}

		public void Select(Item item)
		{
			selected?.Invoke(item);
		}

		private Category GetCategory(Item item)
		{
			if (item.HasAttribute<DamageAttribute>())
			{
				return Category.Weapon;
			}
			else if (item.HasAttribute<ArmorClassAttribute>())
			{
				return Category.Armor;
			}

			return Category.None;
		}

		private void Build()
		{
			Cleanup();


			var equippedItems = equipment.AllItems.Where(item => item != null).ToArray();

			for (int i = 0; i < equippedItems.Length; i++)
			{
				TryAdd(equippedItems[i], true);
			}

			for (int i = 0; i < inventory.Value.Items.Count; i++)
			{
				TryAdd(inventory.Value.Items[i].Item, false);
			}
		}

		private void TryAdd(Item item, bool isEquipped)
		{
			var category = GetCategory(item);

			if (categoryObjects.TryGetValue(category, out var value))
			{
				value.Add(item, isEquipped);
			}
		}

		protected override void OnOpen()
		{
			eventSystem.SetSelectedGameObject(gameObject);

			Build();

			Focus();
		}

		public void Focus()
		{
			StartCoroutine(SelectAtEndOfFrame());
		}

		private GameObject GetCurrentSelection()
		{
			return previouslySelected ?? gameObject.GetComponentInChildren<ItemTemplate>()?.gameObject;
		}

		protected override void OnClose()
		{
			previouslySelected = null;
		}

		private IEnumerator SelectAtEndOfFrame()
		{
			yield return new WaitForEndOfFrame();

			var selected = GetCurrentSelection();

			previouslySelected = selected;

			if (selected != null)
			{
				eventSystem.SetSelectedGameObject(selected);
			}
		}

		public override void OnFocus()
		{
			Focus();
		}

		public void SetTarget(GameObject target)
		{
			if (target != null)
			{
				target.TryGetComponent(out equipment);
			}
		}
	}
}
