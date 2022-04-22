using System.Collections.Generic;
using JuniperJackal.Entity;
using JuniperJackal.Extensions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEngine.UI.Button;

namespace JuniperJackal.UI
{
	public class InventoryCategory : MonoBehaviour
	{
		public InventoryWindow InventoryWindow;
		private List<UnityAction> listeners = new List<UnityAction>();

		private GameObject CreateItem(Item item, bool isEquipped)
		{
			var instance = Instantiate(InventoryWindow.Prefab, transform);

			if (instance.TryGetComponent(out ItemTemplate template))
			{
				template.SetItem(item, isEquipped);
			}

			if (instance.TryGetComponent(out Button button))
			{
				listeners.Add(Subscribe(button.onClick, () => OnClick(button)));
			}

			return instance;
		}

		public void Add(Item item) => Add(item, false);
		public void Add(Item item, bool isEquipped)
		{
			CreateItem(item, isEquipped);
			gameObject.SetActive(true);
		}

		private void Cleanup()
		{
			gameObject.DestroyChildren();

			for (int i = listeners.Count - 1; i >= 0; i--)
			{
				listeners[i]();
				listeners.RemoveAt(i);
			}
		}

		public void Clear()
		{
			Cleanup();
			gameObject.SetActive(false);
		}

		private UnityAction Subscribe(ButtonClickedEvent evt, UnityAction action)
		{
			evt.AddListener(action);

			return () => evt.RemoveListener(action);
		}

		private void OnClick(Button button)
		{
			if (button.gameObject.TryGetComponent(out ItemTemplate template))
			{
				InventoryWindow.Select(template.Item);
			}
		}
	}
}