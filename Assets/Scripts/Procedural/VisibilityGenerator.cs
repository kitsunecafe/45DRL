using System.Collections;
using System.Collections.Generic;
using JuniperJackal.Entity;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

namespace JuniperJackal.Procedural
{
	public class VisibilityGenerator : MonoBehaviour
	{
		[SerializeField] private Tilemap tilemap;
		[SerializeField] private Tilemap fovTilemap;
		[SerializeField] private FieldOfView target;
		[SerializeField] private TileBase undiscoveredTile;
		[SerializeField] private TileBase discoveredTile;
		[SerializeField] private GameObjectValueList entities;
		[SerializeField] private List<SpriteRenderer> activeSprites = new List<SpriteRenderer>();

		[SerializeField] private UnityEvent fovCalculated;

		private Vector2Int previousPosition = default;
		private HashSet<Vector2Int> previouslyVisible = new HashSet<Vector2Int>();

		// private void OnEnable()
		// {
		// 	// register to entities, check if newly added sprites are in view, remove active ones that are removed from entities 
		// 	entities.Added.Register(EntityAdded);
		// 	entities.Removed.Register(EntityRemoved);
		// }

		// private void OnDisable()
		// {
		// 	entities.Added.Unregister(EntityAdded);
		// 	entities.Removed.Unregister(EntityRemoved);
		// }

		// private void EntityAdded(GameObject entity)
		// {

		// }

		// private void EntityRemoved(GameObject entity)
		// {

		// }

		[ContextMenu("Calculate")]
		public void CreateFOV()
		{
			fovTilemap.ClearAllTiles();
			previouslyVisible.Clear();
			activeSprites.Clear();

			var count = tilemap.cellBounds.size.x * tilemap.cellBounds.size.y;
			var tiles = new TileBase[count];

			for (int i = 0; i < count; i++)
			{
				tiles[i] = undiscoveredTile;
			}

			fovTilemap.SetTilesBlock(tilemap.cellBounds, tiles);

			fovTilemap.CompressBounds();

			fovCalculated?.Invoke();
		}

		private void OnDestroy()
		{
			if (target != null)
			{
				target.Recalculated -= OnTargetRecalculate;
			}
		}

		public void OnTargetRecalculate()
		{
			var position = target.ViewerPosition;
			if (target != null)
			{
				RenderVisibility();

				previousPosition = position;
			}
		}

		[ContextMenu("Render Visibility")]
		public void RenderVisibility()
		{
			RenderTilemap();
			RenderEntities();
		}

		private void RenderTilemap()
		{
			// Only repaint the tiles which are not still visible
			previouslyVisible.SymmetricExceptWith(target.Positions);

			var halfClear = new Color(0f, 0f, 0f, 0.5f);
			foreach (var position in previouslyVisible)
			{
				fovTilemap.SetColor((Vector3Int)position, halfClear);
			}

			// Reset positions in order to create new set
			previouslyVisible.Clear();
			var clear = Color.clear;

			foreach (var position in target.Positions)
			{
				previouslyVisible.Add(position);

				var pos = (Vector3Int)position;
				fovTilemap.SetTileFlags(pos, TileFlags.None);
				fovTilemap.SetColor(pos, clear);
			}
		}

		private void RenderEntities()
		{
			for (int i = 0; i < entities.Count; i++)
			{
				var entity = entities[i];
				if (entity.TryGetComponent<SpriteRenderer>(out var renderer))
				{
					renderer.enabled = target.Positions.Contains(Vector2Int.RoundToInt(entity.transform.position));
				}
			}
		}

		public void AssignTarget(GameObject gameObject)
		{
			if (target != null)
			{
				target.Recalculated -= OnTargetRecalculate;
			}
			
			if (gameObject != null && gameObject.TryGetComponent<FieldOfView>(out var fov))
			{
				target = fov;
				target.Recalculated += OnTargetRecalculate;
			}
		}
	}
}
