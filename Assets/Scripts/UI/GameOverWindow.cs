using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace JuniperJackal.UI
{
	public class GameOverWindow : Window
	{
		[SerializeField] private UnityEvent OnRestart;

		protected override void OnOpen()
		{
			InputSystem.onAnyButtonPress.CallOnce(ctrl => OnRestart?.Invoke());
		}
	}
}
