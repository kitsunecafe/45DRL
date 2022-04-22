using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace JuniperJackal.UI
{
	public class Window : MonoBehaviour, ISelectHandler, ICancelHandler
	{
		public bool IsOpen { get; protected set; } = false;
		[SerializeField] private bool startClosed = true;
		[SerializeField] protected UnityEvent Opened;
		[SerializeField] protected UnityEvent Closed;

		private EventSystem _eventSystem;
		protected EventSystem eventSystem => _eventSystem ?? (_eventSystem = EventSystem.current);

		protected virtual void Start()
		{
			WindowManager.Instance.Register(this);
			Initialize();

			if (startClosed)
			{
				Close();
			}
		}

		protected virtual void OnDestroy()
		{
			WindowManager.Instance?.Unregister(this);
		}

		protected virtual void Initialize() { }

		public bool HasFocus()
		{
			return WindowManager.Instance.FocusedWindow() == this;
		}

		public void Open()
		{
			IsOpen = true;
			WindowManager.Instance.Open(this);
			OnOpen();
			Opened?.Invoke();
		}

		public void Close()
		{
			IsOpen = false;
			WindowManager.Instance.Close(this);
			OnClose();
			Closed?.Invoke();
		}

		public void Toggle()
		{
			if (IsOpen) { Close(); }
			else { Open(); }
		}

		protected virtual void OnOpen() { }
		protected virtual void OnClose() { }

		public void MoveToFront()
		{
			WindowManager.Instance.MoveToFront(this);
		}

		public void MoveToBack()
		{
			WindowManager.Instance.MoveToBack(this);
		}

		public virtual void OnFocus() { }

		public virtual void OnSelect(BaseEventData eventData)
		{
			MoveToFront();
		}

		public virtual void OnCancel(BaseEventData eventData)
		{
			Close();
		}
	}
}
