using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace JuniperJackal
{
	public class AssignCollider2DToVariable : MonoBehaviour
	{
		[SerializeField] private Collider2D colliderObj;
		[SerializeField] private Collider2DVariable variable;

#if UNITY_EDITOR
		private void Reset()
		{
			TryGetComponent(out colliderObj);
		}
#endif

		private void Awake()
		{
			variable.Value = colliderObj;
		}
	}
}
