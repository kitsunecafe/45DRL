using System.Collections.Generic;
using System.Linq;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace JuniperJackal
{
	public class PointBuySystem : MonoBehaviour
	{
		[SerializeField] private IntReference attribute;
		[SerializeField] private IntReference points;

		private IReadOnlyDictionary<int, int> costs = new Dictionary<int, int>
		{
			{8,  0},
			{9,  1},
			{10, 2},
			{11, 3},
			{12, 4},
			{13, 5},
			{14, 7},
			{15, 9}
		};

		private void Start()
		{
			attribute.Value = costs.Keys.Min();
		}

		public void TryIncrease()
		{
			TryAdjustValue(1);
		}

		public void TryDecrease()
		{
			TryAdjustValue(-1);
		}

		private void TryAdjustValue(int value)
		{
			if (costs.TryGetValue(attribute.Value + value, out var cost))
			{
				var diff = costs[attribute.Value] - cost;
				if (diff > 0 || (diff < 0 && points.Value >= Mathf.Abs(diff)))
				{
					points.Value += diff;
					attribute.Value += value;
				}
			}
		}
	}
}
