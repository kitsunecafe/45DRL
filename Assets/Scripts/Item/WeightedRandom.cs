using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace JuniperJackal
{
	// https://gamedev.stackexchange.com/questions/162976/how-do-i-create-a-weighted-collection-and-then-pick-a-random-element-from-it
	[Serializable]
	public class WeightedRandom<T>
	{
		[Serializable]
		private struct Entry
		{
			public T Value;
			public float AccumulatedWeight;
		}

		private List<Entry> entries = new List<Entry>();
		private float accumulatedWeight;

		public int Count => entries.Count;

		public void AddEntry(T item, float weight)
		{
			accumulatedWeight += weight;
			entries.Add(new Entry { Value = item, AccumulatedWeight = accumulatedWeight });
		}

		public T GetRandom()
		{
			var rnd = Random.Range(0.1f, accumulatedWeight);

			foreach (var entry in entries)
			{
				if (entry.AccumulatedWeight >= rnd)
				{
					return entry.Value;
				}
			}

			return default(T);
		}
	}
}
