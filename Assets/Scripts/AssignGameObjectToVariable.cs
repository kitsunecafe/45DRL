using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace JuniperJackal
{
	public class AssignGameObjectToVariable : MonoBehaviour
	{
		[SerializeField] private GameObject go;
		[SerializeField] private GameObjectVariable variable;

#if UNITY_EDITOR
		private void Reset()
		{
			go = gameObject;
		}
#endif

		private void OnEnable()
		{
			variable.Value = go;
		}

		private void OnDisable()
		{
			variable.Value = null;
		}
	}
}
