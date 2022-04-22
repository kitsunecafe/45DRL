using System.Collections.Generic;
using System.Linq;
using JuniperJackal.Extensions;
using UnityEngine;

namespace JuniperJackal.Procedural
{
	public class BSPGenerator : AbstractMapGenerator
	{
		[SerializeField] private int minRoomWidth = 4;
		[SerializeField] private int minRoomHeight = 4;

		[SerializeField] private int width = 20;
		[SerializeField] private int height = 20;

		[SerializeField, Range(0, 10)]
		private int offset = 1;

		protected override void Execute()
		{
			CreateRooms();
		}

		private void CreateRooms()
		{
			Floor.Clear();
			Walls.Clear();
			Rooms.Clear();

			var bounds = new BoundsInt(
					(Vector3Int)startPosition,
					new Vector3Int(width, height, 0)
			);

			var rooms = Algorithms.BinarySpacePartition(bounds, minRoomWidth, minRoomHeight);

			var floor = CreateSimpleRooms(rooms);

			var centers = new List<Vector2Int>();

			foreach (var room in rooms)
			{
				centers.Add((Vector2Int)Vector3Int.RoundToInt(room.center));
			}

			var corridors = ConnectRooms(centers);
			floor.UnionWith(corridors);

			var walls = WallGenerator.FindNeighboring(floor);
			
			Floor = floor;
			Walls = walls;

			interpreter.PaintFloorTiles(floor);
			interpreter.PaintWallTiles(walls);
		}

		private HashSet<Vector2Int> ConnectRooms(List<Vector2Int> centers)
		{
			var corridors = new HashSet<Vector2Int>();
			var current = centers.RandomItem();
			centers.Remove(current);

			while (!centers.IsEmpty())
			{
				var closest = FindClosestPointTo(current, centers);
				centers.Remove(closest);

				var corridor = CreateCorridor(current, closest);
				current = closest;

				corridors.UnionWith(corridor);
			}

			return corridors;
		}

		private HashSet<Vector2Int> CreateCorridor(Vector2Int current, Vector2Int destination)
		{
			var corridor = new HashSet<Vector2Int>();
			var position = current;
			corridor.Add(position);

			while (position.y != destination.y)
			{
				if (destination.y > position.y)
				{
					position += Vector2Int.up;
				}
				else if (destination.y < position.y)
				{
					position += Vector2Int.down;
				}

				corridor.Add(position);
			}

			while (position.x != destination.x)
			{
				if (destination.x > position.x)
				{
					position += Vector2Int.right;
				}
				else if (destination.x < position.x)
				{
					position += Vector2Int.left;
				}

				corridor.Add(position);
			}

			return corridor;
		}

		private Vector2Int FindClosestPointTo(Vector2Int current, List<Vector2Int> centers)
		{
			var closest = Vector2Int.zero;
			var minDistance = float.MaxValue;

			foreach (var center in centers)
			{
				var distance = SqrDistance(center, current);

				if (distance < minDistance)
				{
					minDistance = distance;
					closest = center;
				}
			}

			return closest;
		}

		private int SqrDistance(Vector2Int a, Vector2Int b) => (a - b).sqrMagnitude;

		private HashSet<Vector2Int> CreateSimpleRooms(List<BoundsInt> rooms)
		{
			var floor = new HashSet<Vector2Int>();
			foreach (var room in rooms)
			{
				var roomPoints = new HashSet<Vector2Int>();

				for (int col = offset; col < room.size.x - offset; col++)
				{
					for (int row = 0; row < room.size.y - offset; row++)
					{
						var position = (Vector2Int)room.min + new Vector2Int(col, row);
						floor.Add(position);
						roomPoints.Add(position);
					}
				}

				Rooms.Add(roomPoints.ToList());
			}

			return floor;
		}
	}
}
