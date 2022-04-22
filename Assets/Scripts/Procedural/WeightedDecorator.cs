using UnityEngine;
using static JuniperJackal.Procedural.SimpleDecorator;

namespace JuniperJackal.Procedural
{
	[CreateAssetMenu(fileName = "WeightedDecorator", menuName = "Roguelike/Decorators/Weighted Decorator")]
	public class WeightedDecorator : ScriptableObject, IDecorator
	{
		[System.Serializable]
		public class WeightedDecoration : SimpleDecoration
		{
			public int Weight = 1;
		}

		public WeightedDecoration[] Decorations;
		private WeightedRandom<SimpleDecoration> table;

		private void Initialize()
		{
			if (Decorations == null)
			{
				return;
			}

			table = new WeightedRandom<SimpleDecoration>();

			for (int i = 0; i < Decorations.Length; i++)
			{
				table.AddEntry(Decorations[i], Decorations[i].Weight);
			}
		}

		private void OnEnable()
		{
			Initialize();
		}

		private void OnValidate()
		{
			Initialize();
		}

		public IDecoration Create()
		{
			return table.GetRandom();
		}
	}
}
