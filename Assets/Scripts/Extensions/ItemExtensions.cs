using System;
using System.Collections.Generic;
using System.Linq;
using JuniperJackal.Entity;
using UnityEngine;
using Object = UnityEngine.Object;

namespace JuniperJackal.Extensions
{
	public static class ItemExtensions
	{

		public static IEnumerable<T> OfType<T>(this Item item)
		{
			return item.Attributes?.OfType<T>() ?? Enumerable.Empty<T>();
		}

		public static Item Clone(this Item item)
		{
			var baseItem = Object.Instantiate(item);
			baseItem.name = item.name;

			var attributes = item.Attributes.Select(Object.Instantiate<ItemAttribute>).ToArray();
			baseItem.Attributes.Clear();
			baseItem.Attributes.AddRange(attributes);

			return baseItem;
		}

		public static string GetName(this Item item)
		{
			return item.OfType<NameAttribute>().Select(name => name.Value).DefaultIfEmpty().First();
		}

		public static UnityEngine.Sprite GetSprite(this Item item)
		{
			return item.Attributes.OfType<SpriteAttribute>().Select(name => name.Value).DefaultIfEmpty().First();
		}

		public static bool HasAttribute<T>(this Item item) where T : ItemAttribute
		{
			return item?.GetAttributes<T>().Any() ?? false;
		}

		public static bool HasAttribute(this Item item, Type type)
		{
			return item.GetAttributes(type).Any();
		}

		public static bool HasProperty<T>(this Item item) where T : ItemProperty
		{
			return item.HasAttribute<T>();
		}

		public static IEnumerable<T> GetAttributes<T>(this Item item) where T : ItemAttribute
		{
			return item?.Attributes.OfType<T>() ?? Enumerable.Empty<T>();
		}

		public static T GetSingleAttribute<T>(this Item item) where T : ItemAttribute
		{
			return GetAttributes<T>(item).First();
		}

		public static IEnumerable<ItemAttribute> GetAttributes(this Item item, Type type)
		{
			return item.Attributes.Where(i => i.GetType() == type) ?? Enumerable.Empty<ItemAttribute>();
		}

		public static IEnumerable<T> GetProperties<T>(this Item item) where T : ItemProperty
		{
			return item.GetAttributes<T>();
		}
	}
}
