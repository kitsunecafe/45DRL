using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace JuniperJackal
{
	public class ObservableCollider : MonoBehaviour
	{
		[SerializeField] private new Collider2D collider;
		[SerializeField] private UnityEvent<Collider2D> ColliderChanged;
		private Bounds bounds;

#if UNITY_EDITOR
		private void Reset()
		{
			TryGetComponent(out collider);
		}
#endif

		private void Start()
		{
			bounds = collider.bounds;
		}

		private void Update()
		{
			if (collider.bounds.center != bounds.center || collider.bounds.extents != bounds.extents)
			{
				bounds = collider.bounds;
				ColliderChanged?.Invoke(collider);
			}
		}
	}
}
