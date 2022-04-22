using System.Collections;
using System.Collections.Generic;
using JuniperJackal.Procedural;
using UnityEngine;

namespace JuniperJackal.Entity
{
	public class FieldOfView : MonoBehaviour
	{
		[SerializeField] private float radius = default;

		public delegate void FovHandler();
		public event FovHandler Recalculated = delegate { };

		private ColliderGrid grid;
		public ColliderGrid Grid => grid;
		private Vector2Int size = Vector2Int.zero;
		public Vector2Int ViewerPosition => Vector2Int.RoundToInt(transform.position);
		public HashSet<Vector2Int> Positions => grid.VisiblePositions;

		public void OnTilemapColliderChange(Collider2D collider)
		{
			size = Vector2Int.CeilToInt(collider.bounds.min + collider.bounds.max + Vector3.one);
			OnMapGeneration();
		}

		public void OnMapGeneration()
		{
			grid = new ColliderGrid(size);
		}

		[ContextMenu("Calculate")]
		public void Calculate()
		{
			if (grid == null || !enabled) { return; }

			grid.Clear();
			ShadowCast.ComputeVisibility(grid, ViewerPosition, radius);

			Recalculated?.Invoke();
		}

		// private void OnDrawGizmos()
		// {
		// 	Gizmos.color = Color.green;

		// 	foreach (var position in Positions)
		// 	{
		// 		Gizmos.DrawCube((Vector2)position, Vector3.one);
		// 	}

		// 	Gizmos.color = Color.yellow;
		// 	Gizmos.DrawWireCube((Vector2)size / 2, (Vector2)size);
		// }
	}
}
