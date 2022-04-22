using System.Collections.Generic;
using JuniperJackal.Extensions;
using UnityEngine;

namespace JuniperJackal.Procedural
{
	public class DrunkenWalkGenerator : AbstractMapGenerator
	{
		[SerializeField] protected DrunkenWalkParameters parameters;
		protected override void Execute()
		{
			var floor = CreateRandomWalk(startPosition);
			var walls = WallGenerator.FindNeighboring(floor, Direction2D.CardinalDirections);
			interpreter.PaintFloorTiles(floor);
			interpreter.PaintWallTiles(walls);
		}

		protected HashSet<Vector2Int> CreateRandomWalk(Vector2Int position)
		{
			var currentPosition = position;
			var positions = new HashSet<Vector2Int>();

			for (int i = 0; i < parameters.Iterations; i++)
			{
				var path = Procedural.Algorithms.DrunkenWalk(currentPosition, parameters.WalkLength);
				positions.UnionWith(path);

				if (parameters.StartRandomlyEachIteration)
				{
					currentPosition = positions.RandomItem();
				}
			}

			return positions;
		}
	}
}