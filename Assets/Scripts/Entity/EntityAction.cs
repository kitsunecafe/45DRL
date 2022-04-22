using System;
using UnityEngine;

namespace JuniperJackal.Entity
{
	public abstract class EntityAction : MonoBehaviour
	{
		[SerializeField] protected EntityController entity;

#if UNITY_EDITOR
		private void Reset()
		{
			TryGetComponent(out entity);
		}
#endif

		public abstract bool WantsToExecute();
		public abstract void Execute();
	}
}
