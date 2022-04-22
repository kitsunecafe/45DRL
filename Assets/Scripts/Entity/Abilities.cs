using System;
using System.Collections.Generic;
using System.Linq;
using JuniperJackal.Extensions;
using UnityEngine;

namespace JuniperJackal.Entity
{
	public class Abilities : MonoBehaviour
	{
		public static Ability Max() => new Ability(20);
		public static Ability Min() => new Ability(1);
		public static Ability Average() => new Ability(10);

		[SerializeField] private Ability strength = Average();
		public Ability Strength => strength;
		[SerializeField] private Ability dexterity = Average();
		public Ability Dexterity => dexterity;
		[SerializeField] private Ability constitution = Average();
		public Ability Constitution => constitution;
		[SerializeField] private Ability intelligence = Average();
		public Ability Intelligence => intelligence;
		[SerializeField] private Ability wisdom = Average();
		public Ability Wisdom => wisdom;
		[SerializeField] private Ability charisma = Average();
		public Ability Charisma => charisma;

		public int ToHit => Strength.Modifier;

		public int AbilityModifier(Item item)
		{
			List<int> modifiers = new List<int>();
			
			if (item.HasProperty<MeleeProperty>())
			{
				modifiers.Add(Strength.Modifier);
			}

			if (item.HasProperty<FinesseProperty>() || item.HasProperty<RangeProperty>())
			{
				modifiers.Add(Dexterity.Modifier);
			}

			return modifiers.DefaultIfEmpty(0).Max();
		}

		public IEnumerable<int> AbilityModifier(IEnumerable<Item> items)
		{
			return items.Select(AbilityModifier);
		}

		public int BaseArmorClass => 10 + Dexterity.Modifier;
	}
}
