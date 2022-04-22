using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace JuniperJackal.Procedural
{
	public class DrunkenCorridorGenerator : DrunkenWalkGenerator
	{
		[SerializeField] private int length = 15;
		[SerializeField] private int count = 5;

		[SerializeField, Range(0.1f, 1f)]
		private float roomPercent = 0.8f;

		protected override void Execute()
		{
			var floor = new HashSet<Vector2Int>();
			var corridors = GenerateCorridors();
			var potentialRooms = corridors.Select(corridor => corridor.Last());

			foreach (var corridor in corridors)
			{
				floor.UnionWith(corridor);
			}

			var rooms = CreateRooms(potentialRooms, roomPercent);

			var deadEnds = FindDeadEnds(floor);
      var deadEndRooms = CreateRooms(deadEnds, 1f);

			floor.UnionWith(rooms);
      floor.UnionWith(deadEndRooms);

			var walls = WallGenerator.FindNeighboring(floor, Direction2D.CardinalDirections);

			interpreter.PaintFloorTiles(floor);
			interpreter.PaintWallTiles(walls);
		}

		private List<Vector2Int> FindDeadEnds(HashSet<Vector2Int> floor)
		{
			var deadEnds = new List<Vector2Int>();

			foreach (var position in floor)
			{
				var neighborCount = 0;
				foreach (var direction in Direction2D.CardinalDirections)
				{
					if (floor.Contains(position + direction))
					{
						neighborCount += 1;
					}
				}

				if (neighborCount == 1)
				{
					deadEnds.Add(position);
				}
			}

      return deadEnds;
		}

		private HashSet<Vector2Int> CreateRooms(IEnumerable<Vector2Int> potentialPositions, float percent)
		{
			var positions = new HashSet<Vector2Int>();
			var count = Mathf.RoundToInt(potentialPositions.Count() * percent);

			var rooms = potentialPositions.OrderBy(x => Guid.NewGuid()).Take(count).ToList();

			foreach (var position in rooms)
			{
				var floor = CreateRandomWalk(position);
				positions.UnionWith(floor);
			}

			return positions;
		}

		private List<List<Vector2Int>> GenerateCorridors()
		{
			var corridors = new List<List<Vector2Int>>();
			var current = startPosition;

			for (int i = 0; i < count; i++)
			{
				var path = Algorithms.DrunkenWalkCorridor(current, length);
				current = path.Last();
				corridors.Add(path);
			}

			return corridors;
		}
	}
}
