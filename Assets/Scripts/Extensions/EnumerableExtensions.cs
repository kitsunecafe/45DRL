using System;
using System.Collections.Generic;
using System.Linq;

namespace JuniperJackal.Extensions
{
	public static class EnumerableExtensions
	{

		public static T RandomItem<T>(this IEnumerable<T> source) => RandomItemWith(source, new Random());
		public static T RandomItemWith<T>(this IEnumerable<T> source, Random rng)
		{
			T current = default(T);
			int count = 0;

			foreach (T element in source)
			{
				count++;
				if (rng.Next(count) == 0)
				{
					current = element;
				}
			}

			if (count == 0)
			{
				throw new InvalidOperationException("Sequence is empty");
			}

			return current;
		}

		public static bool IsEmpty<T>(this IEnumerable<T> enumerable)
		{
			return !(enumerable?.Any() ?? false);
		}
	}
}
