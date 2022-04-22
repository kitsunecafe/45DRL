using UnityEngine;
using UnityEngine.Events;

namespace JuniperJackal.UI
{
	public class EnableEvents : MonoBehaviour
	{
		[SerializeField] private UnityEvent Enabled;
		[SerializeField] private UnityEvent Disabled;

		private void OnEnable()
		{
			Enabled?.Invoke();
		}

		private void OnDisable()
		{
			Disabled?.Invoke();
		}
	}
}