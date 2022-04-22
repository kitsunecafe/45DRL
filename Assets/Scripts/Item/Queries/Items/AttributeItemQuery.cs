using System;
using System.Collections.Generic;
using System.Linq;
using JuniperJackal.Extensions;
using UnityEngine;

namespace JuniperJackal.Entity
{
	[CreateAssetMenu(fileName = "AttributeItemQuery", menuName = "Roguelike/Query/Attribute Item Query", order = 0)]
	public class AttributeItemQuery : ScriptableObject, IItemQuery
	{
		public List<ItemAttribute> RequiredAttributes;
		private Type[] requiredTypes;


		private void OnValidate()
		{
			requiredTypes = RequiredAttributes.Select(attr => attr.GetType())
				.Distinct()
				.ToArray();
		}

		public IEnumerable<Item> Execute()
		{
			var allItems = ItemRegistry.Instance.Items;
			return RequiredAttributes.Count == 0 ? allItems : allItems
				.Where(HasRequiredAttribute)
				.Where(MatchesValue);
		}

		private bool HasRequiredAttribute(Item item)
		{
			return requiredTypes.Any(item.HasAttribute);
		}

		private bool MatchesValue(Item item)
		{
			return RequiredAttributes.Any(
				a => item.Attributes.Any(b => a.Equals(b))
			);
		}
	}
}
