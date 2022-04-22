using System.Linq;
using JuniperJackal.Entity;
using JuniperJackal.Extensions;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

namespace JuniperJackal.UI
{
	public class InventoryUI : MonoBehaviour
	{
		// Inventory Menu
		private const string ContainerName = "container";
		private const string InventoryMenuName = "inventory-menu";

		private const string HideClass = "hide";

		// Inventory Item Template
		private const string TemplateButtonName = "container";
		private const string TemplateImageName = "image";
		private const string TemplateLabelName = "text";

		[SerializeField] private UIDocument document;
		[SerializeField] private VisualTreeAsset messageTemplate;
		[SerializeField] private Equipment equipment;
		[SerializeField] private InventoryReference inventory;

		[SerializeField] private UnityEvent Opened;
		[SerializeField] private UnityEvent Closed;

		private VisualElement container;
		private VisualElement inventoryMenu;

#if UNITY_EDITOR
		private void Reset()
		{
			TryGetComponent(out document);
		}
#endif

		private void Start()
		{
			var root = document.rootVisualElement;
			container = root.Q(ContainerName);
			inventoryMenu = container.Q(InventoryMenuName);
		}

		private void OnItemClick(EventBase evt)
		{
			InventoryItem item = (evt.target as VisualElement).userData as InventoryItem;
			var slot = item.Item.Attributes.OfType<EquipmentSlotAttribute>().First();

			if (equipment.Equip(item.Item, slot.Value))
			{
				Hide();
			}
		}

		private void ClearInventory()
		{
			foreach (var element in inventoryMenu.Children())
			{
				var button = element.Q(TemplateButtonName);
				button.UnregisterCallback<FocusEvent>(HandleFocusGained);
				button.UnregisterCallback<BlurEvent>(HandleFocusLost);
			}

			inventoryMenu.Clear();
		}

		private void Build()
		{
			ClearInventory();

			if (inventory.Value.Items.Count == 0) { return; }
			foreach (var item in inventory.Value.Items)
			{
				var element = messageTemplate.CloneTree();
				var img = element.Q(TemplateImageName);
				img.style.backgroundImage = new StyleBackground(item.Item.GetSprite());

				var button = element.Q<Button>(TemplateButtonName);
				var label = button.Q<Label>(TemplateLabelName);
				label.text = item.Item.GetName();

				button.RegisterCallback<FocusEvent>(HandleFocusGained);
				button.RegisterCallback<BlurEvent>(HandleFocusLost);
				button.clickable.clickedWithEventInfo += OnItemClick;
				button.userData = item;

				inventoryMenu.Add(element);
			}
		}

		private void HandleFocusGained(FocusEvent evt)
		{
			Debug.Log($"Focusing {evt.target}");
			(evt.target as VisualElement).Q(TemplateButtonName).AddToClassList("selected");
		}

		private void HandleFocusLost(BlurEvent evt)
		{
			(evt.target as VisualElement)?.Q(TemplateButtonName).RemoveFromClassList("selected");
		}

		public void Show()
		{
			container.RemoveFromClassList(HideClass);

			Build();

			TryFocus();
			Opened.Invoke();
		}

		private void TryFocus()
		{
			if (inventoryMenu.childCount > 0)
			{
				inventoryMenu.Children().First().ElementAt(0).Focus();
			}
		}

		public void Hide()
		{
			container.AddToClassList(HideClass);
			Closed.Invoke();
		}

		public void Toggle()
		{
			if (container.ClassListContains(HideClass))
			{
				Show();
			}
			else
			{
				Hide();
			}
		}

		public void UseEquipmentFrom(GameObject gameObject)
		{
			gameObject.TryGetComponent(out equipment);
		}
	}
}
