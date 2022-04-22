using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace JuniperJackal.UI
{
	public class WindowManager : MonoBehaviour
	{
		public static WindowManager Instance { get; private set; }

		private List<Window> windows = new List<Window>();
		private List<Window> activeWindows = new List<Window>();
		

		private EventSystem _eventSystem;
		private EventSystem eventSystem
		{
			get
			{
				if (_eventSystem == null)
				{
					_eventSystem = EventSystem.current;
				}

				return _eventSystem;
			}
		}

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

		public void Register(Window window)
		{
			windows.Add(window);
		}

		public void Unregister(Window window)
		{
			windows.Remove(window);
		}

		public void Open(Window window)
		{
			activeWindows.Add(window);
			Select(window);
		}

		public void Close(Window window)
		{
			activeWindows.Remove(window);

			if (activeWindows.Any())
			{
				Select(activeWindows.Last());
			}
		}

		public void CloseAll()
		{
			for (int i = activeWindows.Count - 1; i >= 0; i--)
			{
				activeWindows[i].Close();
			}
		}

		public Window FocusedWindow()
		{
			return activeWindows.Last();
		}

		private void Select(Window window)
		{
			window.OnFocus();
			Select(window.gameObject);
		}

		private void Select(GameObject gameObject)
		{
			eventSystem.SetSelectedGameObject(gameObject);
		}

		public void MoveToFront(Window window)
		{
			activeWindows.Remove(window);
			activeWindows.Add(window);
		}

		public void MoveToBack(Window window)
		{
			activeWindows.Remove(window);
			activeWindows.Insert(0, window);
		}
	}
}
