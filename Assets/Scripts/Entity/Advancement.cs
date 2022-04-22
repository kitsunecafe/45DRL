using System.Linq;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace JuniperJackal.Entity
{
	public class Advancement : MonoBehaviour
	{
		public const byte MaxLevel = 20;

		// a(x + b)^c
		private static float ExpCurve(int level) => 300 * Mathf.Pow(level - 1, 2);
		private static int[] requiredExperience = Enumerable.Range(1, MaxLevel)
			.Select(ExpCurve)
			.Select(Mathf.RoundToInt)
			.ToArray();

		[SerializeField] private IntReference level;
		public int Level => level.Value;

		[SerializeField] private int experience = 0;

		public void AddExperience(int value)
		{
			experience += value;

			if (experience >= requiredExperience[Level])
			{
				level.Value += 1;
			}
		}
	}
}
