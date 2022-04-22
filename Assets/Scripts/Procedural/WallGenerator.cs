using System.Collections.Generic;
using UnityEngine;

namespace JuniperJackal.Procedural
{
	public static class WallGenerator
  {
		public static HashSet<Vector2Int> FindNeighboring(HashSet<Vector2Int> floor) => FindNeighboring(floor, Direction2D.EightWindDirections);
		public static HashSet<Vector2Int> FindNeighboring(HashSet<Vector2Int> floor, Vector2Int[] directions)
		{
			var positions = new HashSet<Vector2Int>();

			foreach (var position in floor)
			{
				foreach (var direction in directions)
				{
					var neighbor = position + direction;

					if (!floor.Contains(neighbor))
					{
						positions.Add(neighbor);
					}
				}
			}
  
      return positions;
		}
	}
}
