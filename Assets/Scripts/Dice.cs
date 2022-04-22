using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using JuniperJackal.Entity;
using UnityEngine;
using Random = UnityEngine.Random;

namespace JuniperJackal
{
	[Serializable]
	public class Dice
	{
		public static readonly Dice None = new Dice(0, 0);
		public static readonly Dice D4 = new Dice(1, 4);
		public static readonly Dice D6 = new Dice(1, 6);
		public static readonly Dice D8 = new Dice(1, 6);
		public static readonly Dice D20 = new Dice(1, 20);

		public readonly int Count = 1;
		public readonly int Sides = 6;
		public readonly string Modifiers = "";
		public readonly bool HasModifiers = false;
		public static Regex rx = new Regex(@"(?<count>\d+)?d(?<sides>\d+)(?<modifiers>[\+\-]\d+)?");

		public Dice() { }
		public Dice(int count, int sides) : this(count, sides, "") { }

		public Dice(int count, int sides, string modifiers)
		{
			Count = count;
			Sides = sides;
			Modifiers = modifiers.Trim();
			HasModifiers = Modifiers != "";
		}

		public static Dice FromString(string input)
		{
			var match = rx.Match(input);

			if (match.Success)
			{
				var groups = match.Groups;
				var count = groups["count"].Success ? Int32.Parse(groups["count"].Value) : 1;
				var sides = Int32.Parse(groups["sides"].Value);
				var modifiers = groups["modifiers"].Success ? groups["modifiers"].Value : "";
				return new Dice(count, sides, modifiers);
			}

			return null;
		}

		public int Roll() => Roll(this);

		public static int Roll(Dice dice)
		{
			var result = Roll(dice.Count, dice.Sides);

			if (dice.HasModifiers)
			{
				var roll = $"{result}{dice.Modifiers}";
				var arith = Calculator.Evaluate(roll);
				result = Mathf.RoundToInt(arith);
			}

			return result;
		}

		public static int Roll(IEnumerable<Dice> dice)
		{
			return dice.Select(die => die.Roll()).Sum();
		}

		public static int Roll(int number, int sides)
		{
			return Random.Range(number, (sides * number) + 1);
		}

		public static AlterantStatus AttackRoll(int toHit, int ac)
		{
			var result = Roll(Dice.D20);

			switch (result)
			{
				// Critical hit
				case 20: return AlterantStatus.Critical;
				// Critical miss
				case 1: return AlterantStatus.Miss;
				// Standard attack
				default: return result + toHit > ac ? AlterantStatus.Hit : AlterantStatus.Miss;
			}
		}

		public override string ToString()
		{
			return $"{Count}d{Sides} {Modifiers}";
		}
	}
}
