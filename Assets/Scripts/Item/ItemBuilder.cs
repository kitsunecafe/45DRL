using System.Collections.Generic;
using JuniperJackal.Entity;
using UnityEngine;

namespace JuniperJackal
{
	public class ItemBuilder
	{
		private Item item;
		private List<ItemAttribute> attributes = new List<ItemAttribute>();

		public ItemBuilder() {}

		public ItemBuilder(Item item)
		{
			this.item = item;
		}

		private static T CreateAttribute<T>() where T : ItemAttribute
		{
			return ScriptableObject.CreateInstance<T>();
		}

		private ItemBuilder AddAttribute(ItemAttribute attribute)
		{
			attributes.Add(attribute);

			return this;
		}

		public ItemBuilder Reset()
		{
			item = ScriptableObject.CreateInstance<Item>();
			attributes.Clear();

			return this;
		}

		public Item Build()
		{
			for (int i = 0; i < attributes.Count; i++)
			{
				item.Attributes.Add(attributes[i]);
			}

			return item;
		}

		private ItemBuilder AddValueAttribute<T>(ValueAttribute<T> attribute, T value)
		{
			attribute.Value = value;

			return AddAttribute(attribute);
		}

		private ItemBuilder CreateValueAttribute<A, T>(T value) where A : ValueAttribute<T>
		{
			var attribute = CreateAttribute<A>();

			return AddValueAttribute(attribute, value);
		}

		public ItemBuilder SetName(string name)
		{
			return CreateValueAttribute<NameAttribute, string>(name);
		}

		public ItemBuilder AddDamage(string value) => AddDamage(Dice.FromString(value));
		public ItemBuilder AddDamage(Dice value)
		{
			var attribute = CreateAttribute<DamageAttribute>();
			attribute.Dice = value;

			return AddValueAttribute(attribute, value.ToString());
		}

		public ItemBuilder AddSprite(Sprite value)
		{
			return CreateValueAttribute<SpriteAttribute, Sprite>(value);
		}

		public ItemBuilder AddArmorClass(int value)
		{
			return CreateValueAttribute<ArmorClassAttribute, int>(value);
		}

		public ItemBuilder AddProperty<T>() where T : ItemProperty
		{
			return AddAttribute(CreateAttribute<T>());
		}
	}
}
