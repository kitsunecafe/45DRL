using System;
using System.Collections.Generic;
using System.Linq;
using JuniperJackal.Procedural;
using UnityEngine;

namespace JuniperJackal.Entity
{
	public class Interactor : MonoBehaviour
	{
		private List<IInteractable> interactables = new List<IInteractable>();

		public void TryInteract()
		{
			TryInteract(interactables.First());
		}

		public static void TryInteract(IInteractable interactable)
		{
			interactable?.Interact();
		}

		public T GetFirstOfType<T>() where T : IInteractable
		{
			return interactables.OfType<T>().FirstOrDefault();
		}

		public T GetFirstOfType<T>(Func<T, bool> predicate) where T : IInteractable
		{
			return interactables.OfType<T>().FirstOrDefault(predicate);
		}

		public void TryCollectItem()
		{
			TryInteract(
				GetFirstOfType<CollectableItem>()
			);
		}

		public void TryAscend()
		{
			TryInteract(
				GetFirstOfType<ChangeDepth>(cd => cd.Delta < 0)
			);
		}

		public void TryDescend()
		{
			TryInteract(
				GetFirstOfType<ChangeDepth>(cd => cd.Delta > 0)
			);
		}

		public void TryOpen() {
			TryInteract(
				GetFirstOfType<TreasureChest>()
			);
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.TryGetComponent<IInteractable>(out var interactable))
			{
				interactables.Add(interactable);
			}
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			if (other.TryGetComponent<IInteractable>(out var interactable))
			{
				interactables.Remove(interactable);
			}
		}
	}
}
