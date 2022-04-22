using System;
using System.Collections.Generic;
using UnityEngine;

namespace JuniperJackal.Entity
{
	[CreateAssetMenu(menuName = "Roguelike/Item")]
	public class Item : ScriptableObject, IEquatable<Item>
	{
		private static Item none;
		public static Item None => none ?? (none = CreateInstance<Item>());
		
		[SerializeField] private string id = Guid.NewGuid().ToString();
		public string ID => id;

		public int ItemLevel = 1;

		public List<ItemAttribute> Attributes = new List<ItemAttribute>();

		public void ReceiveMessage<T>(T message)
		{
			for (int i = 0; i < Attributes.Count; i++)
			{
				Attributes[i].ReceiveMessage(message);
			}
		}

		public override bool Equals(object obj)
		{
			return obj is Item item && base.Equals(obj) && Equals(item);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(base.GetHashCode(), name, hideFlags, ItemLevel, Attributes);
		}

		public bool Equals(Item other)
		{
			return name == other.name &&
				 id == other.ID &&
				 hideFlags == other.hideFlags &&
				 ItemLevel == other.ItemLevel &&
				 EqualityComparer<List<ItemAttribute>>.Default.Equals(Attributes, other.Attributes);
		}
	}
}
