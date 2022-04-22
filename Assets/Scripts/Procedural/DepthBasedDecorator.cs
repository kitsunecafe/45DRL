using System.Linq;
using JuniperJackal.Extensions;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using static JuniperJackal.Procedural.SimpleDecorator;

namespace JuniperJackal.Procedural
{
	[CreateAssetMenu(fileName = "DepthBasedDecorator", menuName = "Roguelike/Decorators/Depth Based Decorator")]
	public class DepthBasedDecorator : ScriptableObject, IDecorator
	{
		[System.Serializable]
		public class DepthDecoration : SimpleDecoration
		{
			public int TargetDepth;
		}

		public DepthDecoration[] Decorations;
		[SerializeField] public IntVariable depth;
		public int Depth => depth.Value;
		public int Variance = 2;

		public IDecoration Create()
		{
			return Decorations.Where(WithinDepth).RandomItem();
		}

		private bool WithinDepth(DepthDecoration decoration)
		{
			return decoration.TargetDepth >= Depth - Variance
				&& decoration.TargetDepth <= Depth + Variance;
		}
	}
}
