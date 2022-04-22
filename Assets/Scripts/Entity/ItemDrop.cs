using System.Linq;
using JuniperJackal.Extensions;
using UnityEngine;

namespace JuniperJackal.Entity
{
	public class ItemDrop : MonoBehaviour
	{
		[SerializeField] private LootTable lootTable;
		[SerializeField] private GameObject prefab;
		[SerializeField] private Transform parent;

#if UNITY_EDITOR
		private void Reset()
		{
			parent = transform;
		}
#endif

		public void DropItem(Item item, Vector3 position)
		{
			if (item == null || item == Item.None) { return; }

			var obj = Instantiate(prefab, position, Quaternion.identity, parent);

			if (obj.TryGetComponent<CollectableItem>(out var collectable))
			{
				collectable.Item = item;
			}

			if (obj.TryGetComponent<SpriteRenderer>(out var renderer))
			{
				renderer.sprite = item.GetSprite();
			}
		}

		public void DropRandomItem()
		{
			var items = lootTable.SelectRandom().DefaultIfEmpty();

			foreach (var item in items)
			{
				if (item != Item.None)
				{
					DropItem(item, transform.position);
				}
			}
		}
	}
}