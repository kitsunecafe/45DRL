using UnityEngine;
using UnityEngine.Tilemaps;

namespace JuniperJackal
{
	public class LevelManager : MonoBehaviour
	{
		public static LevelManager Instance { get; private set; }

    [SerializeField] private Tilemap levelTilemap;
    public Tilemap LevelTilemap => levelTilemap;

    [SerializeField] private Tilemap visibilityTilemap;
    public Tilemap VisibilityTilemap => visibilityTilemap;

		private void Awake()
		{
			if (Instance != null && Instance != this)
			{
				Destroy(this);
			}
			else
			{
				Instance = this;
			}
		}
	}
}