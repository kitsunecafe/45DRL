using System.Collections.Generic;
using JuniperJackal.Entity;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace JuniperJackal
{
	[CreateAssetMenu(fileName = "ItemRegistry", menuName = "Roguelike/Item Registry")]
	public class ItemRegistry : SingletonScriptableObject<ItemRegistry>, IRegistry<Item>
	{
		private const string ItemLabel = "Item";

		[SerializeField, ReadOnly] private List<Item> items = new List<Item>();
		public IEnumerable<Item> Items => items;

		protected override void OnInitialize()
		{
			LoadItems();
		}

		private void LoadItems()
		{
			items.Clear();
			var handle = Addressables.LoadAssetsAsync<Item>(ItemLabel, items.Add, true);
			handle.Completed += h =>
			{
				Addressables.Release(handle);
			};
		}
	}
}
