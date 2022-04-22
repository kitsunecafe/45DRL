using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace JuniperJackal.Procedural
{
	public class TileMapInterpreter : MonoBehaviour
	{
		[SerializeField] private Tilemap floorTilemap, wallTilemap;
		[SerializeField] private TileBase tile;

		public void PaintFloorTiles(IEnumerable<Vector2Int> positions)
		{
			PlaceTiles(positions, floorTilemap, tile);
		}

		public void PaintWallTiles(IEnumerable<Vector2Int> positions)
		{
			PlaceTiles(positions, wallTilemap, tile);
		}

		private void PlaceTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile)
		{
			foreach (var position in positions)
			{
				PaintTile(position, tilemap, tile);
			}
		}

		private void PaintTile(Vector2Int position, Tilemap tilemap, TileBase tile)
		{
			var tilePosition = tilemap.WorldToCell((Vector3Int)position);
			tilemap.SetTile(tilePosition, tile);
		}

		public void Clear()
		{
			floorTilemap.ClearAllTiles();
			wallTilemap.ClearAllTiles();

			floorTilemap.CompressBounds();
			wallTilemap.CompressBounds();
		}
	}
}
