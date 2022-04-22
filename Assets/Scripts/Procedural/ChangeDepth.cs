using JuniperJackal.Entity;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace JuniperJackal.Procedural
{

	public class ChangeDepth : MonoBehaviour, IInteractable
	{
		[SerializeField] private int delta = 1;
		public int Delta => delta;
		[SerializeField] private IntReference currentDepth = default;

		public virtual bool Interact()
		{
			currentDepth.Value += delta;
			return true;
		}
	}
}