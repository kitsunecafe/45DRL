using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace JuniperJackal.Entity
{
	public class EntityAI : MonoBehaviour
	{
		[SerializeField] private EntityController controller;
		[SerializeField] private FieldOfView fov;
		[SerializeField] private Pathing pathing;

#if UNITY_EDITOR
		private void Reset()
		{
			TryGetComponent(out controller);
			TryGetComponent(out fov);
		}
#endif

		private void Awake()
		{
			pathing = new Pathing();
		}

		public void Act(Vector2Int target)
		{
			if (fov.Positions.Contains(target))
			{
				var currentPosition = Vector2Int.RoundToInt(transform.position);
				var path = pathing.Find(fov.Grid, currentPosition, target).ToList();

				for (int i = 1; i < path.Count; i++)
				{
					Debug.DrawLine((Vector2)path[i - 1], (Vector2)path[i], Color.green, 1f);
				}

				if (path.Count >= 1)
				{
					controller.Direction = path[1] - currentPosition;
				}
				else
				{
					controller.Direction = Vector2Int.zero;
				}
			}
		}
	}
}
