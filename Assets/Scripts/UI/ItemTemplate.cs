using System.Linq;
using JuniperJackal.Entity;
using JuniperJackal.Extensions;
using UnityEngine;
using UnityEngine.Events;

namespace JuniperJackal.UI
{
	public class ItemTemplate : MonoBehaviour
	{
		private const string EquippedTag = "(worn)";

		private Item item;
		public Item Item => item;
		public bool IsEquipped { get; private set; } = false;

		[SerializeField] private UnityEvent<Sprite> SpriteSet;
		[SerializeField] private UnityEvent<string> TextSet;

		public void SetSprite(Sprite sprite)
		{
			SpriteSet?.Invoke(sprite);
		}

		public void SetText(string text)
		{
			TextSet?.Invoke(text);
		}

		public void SetItem(Item item, bool isEquipped)
		{
			if (item == null) { return; }

			this.item = item;
			IsEquipped = isEquipped;

			var sprite = item.GetAttributes<SpriteAttribute>()
				.Select(a => a.Value)
				.DefaultIfEmpty()
				.First();

			var name = item.GetName();

			if (isEquipped)
			{
				name = $"{name} {EquippedTag}";
			}

			SetSprite(sprite);
			SetText(name);
		}
	}
}
