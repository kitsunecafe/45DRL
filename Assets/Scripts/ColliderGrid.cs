using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace JuniperJackal.Procedural
{
	public class ColliderGrid : ICellGrid
	{
		private Vector2Int size = default;
		public int xDim => size.x;

		public int yDim => size.y;

		public HashSet<Vector2Int> VisiblePositions { get; private set; } = new HashSet<Vector2Int>();

		public ColliderGrid(Vector2Int size)
		{
			this.size = size + Vector2Int.one;
		}

		public bool IsWall(int x, int y)
		{
			var collider = Physics2D.OverlapPoint(new Vector2(x, y));
			return collider != null && !collider.isTrigger && collider.gameObject.TryGetComponent<Tilemap>(out var _);
		}

		public void SetLight(int x, int y, float distanceSquared)
		{
			VisiblePositions.Add(new Vector2Int(x, y));
		}

		public void Clear()
		{
			VisiblePositions.Clear();
		}
	}
}
