using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.EventSystems.ExecuteEvents;

namespace JuniperJackal.UI
{
	/// <summary>
	/// Controls the event bubbling behaviour of UnityEngine.UI.Button class.
	/// Sets PointerEventData.pointerPress so it may be used in OnPointerUp.
	///
	/// The Events which are affected are: OnPointerDown, OnPointerUp, OnPointerClick.
	/// </summary>
	public class EventBubbling : MonoBehaviour,
															 IPointerDownHandler,
															 IPointerUpHandler,
															 IPointerClickHandler,
															 ISubmitHandler,
															 ISelectHandler,
															 IDeselectHandler,
															 ICancelHandler
	{
		/// <summary>
		/// DoNotBubble = The Unity default behaviour. Buttons catch all events and do not bubble.
		/// BubbleWithoutTrigger = Buttons bubble events if there is no Event Trigger component attached to the button. If there is an Event Trigger then no bubbling will occur.
		/// BubbleAlways = Buttons will always bubble events.
		/// </summary>
		public enum EventBehaviour { DoNotBubble, BubbleWithoutTrigger, BubbleAlways };

		[Tooltip("Should the Button let events bubble (they usually don't). Only affects PointerUp, PointerDown and PointerClick events.\n\nDoNotBubble:\nThe Unity default behaviour. Buttons catch all events and do not bubble.\n\nBubbleWithoutTrigger:\nButtons bubble some events if there is no Event Trigger component attached to the button. If there is an Event Trigger then no bubbling will occur.\n\nBubbleAlways:\nButtons will always bubble some events (not all).")]
		public EventBehaviour Behaviour = EventBehaviour.BubbleWithoutTrigger;

		[Tooltip("Should OnSubmit be delayed until a key is released?\nUsually onSubmit is executed on key down.")]
		public bool DelaySubmitTilKeyUp = false;

		protected bool hasSelectable;
		protected bool hasEventTrigger;
		protected Coroutine onSubmitOnKeyUpCoroutine;

		private void Awake()
		{
			this.hasSelectable = this.GetComponent<Selectable>() != null;
			if (this.hasSelectable) // tiny optimization, don't ask for Event Trigger if it is not a button
			{
				this.hasEventTrigger = this.GetComponent<EventTrigger>() != null;
			}
		}

		protected void HandleEventPropagation<T>(Transform goTransform, BaseEventData eventData, EventFunction<T> callbackFunction) where T : IEventSystemHandler
		{
			if (hasSelectable && goTransform.parent != null)
			{
				var continueBubblingFromHereObject = goTransform.parent.gameObject;
				switch (Behaviour)
				{
					case EventBehaviour.BubbleAlways:
						// propagate event further up
						ExecuteEvents.ExecuteHierarchy(continueBubblingFromHereObject, eventData, callbackFunction);
						break;
					case EventBehaviour.BubbleWithoutTrigger:
						// propagate event further up only if there is no EventTrigger
						if (this.hasEventTrigger == false)
						{
							ExecuteEvents.ExecuteHierarchy(continueBubblingFromHereObject, eventData, callbackFunction);
						}
						break;
					case EventBehaviour.DoNotBubble:
					default:
						// Do Nothing: default unity behaviour. Up, Down and Click events will not bubble.
						break;
				}
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			eventData.pointerPress = this.gameObject; // Set the usually empty pointerPress in OnPointerDown.
			HandleEventPropagation(transform, eventData, ExecuteEvents.pointerDownHandler);
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			HandleEventPropagation(transform, eventData, ExecuteEvents.pointerUpHandler);
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			HandleEventPropagation(transform, eventData, ExecuteEvents.pointerClickHandler);
		}

		public void OnSubmit(BaseEventData eventData)
		{
			if (DelaySubmitTilKeyUp)
			{
				if (onSubmitOnKeyUpCoroutine != null)
				{
					StopCoroutine(onSubmitOnKeyUpCoroutine);
				}
				onSubmitOnKeyUpCoroutine = StartCoroutine(onSubmitOnKeyUp(transform, eventData));
			}
			else
			{
				HandleEventPropagation(transform, eventData, ExecuteEvents.submitHandler);
			}
		}

		protected System.Collections.IEnumerator onSubmitOnKeyUp(Transform transform, BaseEventData eventData)
		{
			// Wait for the key(s) to be released.
			yield return new WaitWhile(() => Input.anyKey);
			// Wait until the end of the frame to avoid other key dependent input to get triggered instantly.
			yield return new WaitForEndOfFrame();
			HandleEventPropagation(transform, eventData, ExecuteEvents.submitHandler);
			onSubmitOnKeyUpCoroutine = null;
		}

		public void OnCancel(BaseEventData eventData)
		{
			HandleEventPropagation(transform, eventData, ExecuteEvents.cancelHandler);
		}

		public void OnSelect(BaseEventData eventData)
		{
			HandleEventPropagation(transform, eventData, ExecuteEvents.selectHandler);
		}

		public void OnDeselect(BaseEventData eventData)
		{
			HandleEventPropagation(transform, eventData, ExecuteEvents.deselectHandler);
		}
	}
}
