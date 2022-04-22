using System.Collections.Generic;
using JuniperJackal.Extensions;
using UnityEngine;

namespace JuniperJackal.Procedural
{
	public static class Direction2D
	{
		public static Vector2Int[] CardinalDirections = new Vector2Int[]
		{
			Vector2Int.up,
			Vector2Int.right,
			Vector2Int.down,
			Vector2Int.left,
		};

		public static Vector2Int[] EightWindDirections = new Vector2Int[] {
			new Vector2Int(-1, 1),
			Vector2Int.up,
			Vector2Int.one,
			Vector2Int.right,
			new Vector2Int(1, -1),
			Vector2Int.down,
			Vector2Int.one * -1,
			Vector2Int.left,
		};

		public static Vector2Int RandomCardinalDirection()
		{
			return RandomDirection(CardinalDirections);
		}

		public static Vector2Int RandomEightWindDirection()
		{
			return RandomDirection(EightWindDirections);
		}

		public static Vector2Int RandomDirection(Vector2Int[] directions)
		{
			return directions.RandomItem();
		}
	}

	public static class Algorithms
	{
		public static HashSet<Vector2Int> DrunkenWalk(Vector2Int origin, int length)
		{
			var path = new HashSet<Vector2Int>();

			path.Add(origin);
			var previous = origin;

			for (int i = 0; i < length; i++)
			{
				var position = previous + Direction2D.RandomCardinalDirection();
				path.Add(position);
				previous = position;
			}

			return path;
		}

		public static List<Vector2Int> DrunkenWalkCorridor(Vector2Int origin, int length)
		{
			var corridor = new List<Vector2Int>() { origin };

			var direction = Direction2D.RandomCardinalDirection();
			var current = origin;

			for (int i = 0; i < length; i++)
			{
				current += direction;
				corridor.Add(current);
			}

			return corridor;
		}

		public static List<BoundsInt> BinarySpacePartition(BoundsInt space, int minWidth, int minHeight)
		{
			var queue = new Queue<BoundsInt>();
			var rooms = new List<BoundsInt>();

			queue.Enqueue(space);

			while (queue.Count > 0)
			{
				var room = queue.Dequeue();

				if (room.size.y >= minHeight && room.size.x >= minWidth)
				{
					var splitHorizontally = Random.value < 0.5f && room.size.y >= minHeight * 2;

					if (!splitHorizontally && room.size.x < minWidth * 2)
					{
						rooms.Add(room);
						continue;
					}

					var splits = splitHorizontally ? SplitHorizontally(minWidth, room) : SplitVertically(minHeight, room);

					foreach (var split in splits)
					{
						queue.Enqueue(split);
					}
				}
			}

			return rooms;
		}

		private static BoundsInt[] SplitVertically(int minWidth, BoundsInt room)
		{
			var x = Random.Range(1, room.size.x);
			var r1 = new BoundsInt(room.min, new Vector3Int(x, room.size.y, room.size.z));
			var r2 = new BoundsInt(new Vector3Int(room.min.x + x, room.min.y, room.min.z), new Vector3Int(room.size.x - x, room.size.y, room.size.z));

			return new BoundsInt[] { r1, r2 };
		}

		private static BoundsInt[] SplitHorizontally(int minHeight, BoundsInt room)
		{
			var y = Random.Range(1, room.size.y);
			var r1 = new BoundsInt(room.min, new Vector3Int(room.size.x, y, room.size.z));
			var r2 = new BoundsInt(
				new Vector3Int(room.min.x, room.min.y + y, room.min.z),
				new Vector3Int(room.size.x, room.size.y - y, room.size.z)
			);

			return new BoundsInt[] { r1, r2 };
		}
	}
}
