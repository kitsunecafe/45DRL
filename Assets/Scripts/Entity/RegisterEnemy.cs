using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace JuniperJackal.Entity
{
	public class RegisterEnemy : MonoBehaviour
	{
		[SerializeField] private EntityAI entity;
		[SerializeField] private GameObjectValueList enemies;

#if UNITY_EDITOR
		private void Reset()
		{
			TryGetComponents();
		}
#endif

		private void TryGetComponents()
		{
			if (entity == null)
			{
				TryGetComponent(out entity);
			}
		}

		private void Awake()
		{
			TryGetComponents();
		}

		private void Start()
		{
			enemies.Add(gameObject);
		}

		private void OnDestroy()
		{
			enemies.Remove(gameObject);
		}
	}
}
