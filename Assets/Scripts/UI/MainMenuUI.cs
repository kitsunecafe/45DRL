using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

namespace JuniperJackal.UI
{
	public class MainMenuUI : MonoBehaviour
	{
		[SerializeField] private UIDocument document;
    [SerializeField] private UnityEvent startClicked;

		private Button startBtn;
		private Button quitBtn;

#if UNITY_EDITOR
		private void Reset()
		{
			TryGetComponent(out document);
		}
#endif

		private void OnEnable()
		{
			var root = document?.rootVisualElement;

			startBtn = root.Q<Button>("start-button");
			quitBtn = root.Q<Button>("quit-button");

			startBtn.clickable.clicked += HandleStartClick;
		}

		private void OnDisable()
		{
      startBtn.clickable.clicked -= HandleStartClick;
		}

		private void HandleStartClick()
		{
      startClicked?.Invoke();
		}
	}
}