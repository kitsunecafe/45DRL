using System;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace JuniperJackal.Entity
{
	public class ItemAttribute : ScriptableObject, IAttribute
	{
		private static Type[] allAttributeTypes;
		public static Type[] AllAttributeTypes => allAttributeTypes ?? (allAttributeTypes = GetAllAttributeTypes());

		private static Type[] GetAllAttributeTypes()
		{
			return Assembly.GetAssembly(typeof(ItemAttribute))
				.GetTypes()
				.Where(type => type.IsSubclassOf(typeof(ItemAttribute)))
				.Where(type => !type.IsAbstract)
				.ToArray();
		}

		public virtual string Label => "Attribute";
		public virtual string EditorDescription => "An item attribute";
		public virtual string Description => EditorDescription;
		public virtual bool VisibleInDescription => true;

		public virtual bool AllowMultiple => true;
		public virtual bool IsCategory => false;
		public virtual bool Selectable => false;

		private IItem source;
		public IItem Source
		{
			get => source;
			set
			{
				if (value != source)
				{
					source = value;
				}
			}
		}

		public virtual void ReceiveMessage<T>(T message)
		{
		}
	}
}
