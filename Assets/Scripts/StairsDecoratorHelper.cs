using System.Collections;
using System.Linq;
using JuniperJackal.Extensions;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace JuniperJackal.Procedural
{
	public class StairsDecoratorHelper : MonoBehaviour
	{
		[SerializeField] private GameObject stairsUp, stairsDown, stairsOut;
		[SerializeField] private Decorator decorator;

		private int previousDepth = 0;
		private int currentDepth = 1;

		private GameObject entrance
		{
			get
			{
				if (JustEntered())
				{
					return stairsOut;
				}
				else if (IsDescending())
				{
					return stairsUp;
				}
				else
				{
					return stairsDown;
				}
			}
		}

		private GameObject exit
		{
			get
			{
				if (previousDepth == 2 && currentDepth == 1)
				{
					return stairsOut;
				}
				else
				if (JustEntered() || IsDescending())
				{
					return stairsDown;
				}
				else
				{
					return stairsUp;
				}
			}
		}

		private Vector3 position = default;
		private bool waiting = true;

#if UNITY_EDITOR
		private void Reset()
		{
			TryGetComponent(out decorator);
		}
#endif

		private bool JustEntered()
		{
			return previousDepth <= 1 && currentDepth == 1;
		}
		private bool IsDescending()
		{
			return currentDepth > previousDepth;
		}

		public void OnDepthChange(IntPair depths)
		{
			depths.Deconstruct(out currentDepth, out previousDepth);
			OnDepthChange();
		}

		public void OnDepthChange(int current, int previous)
		{
			currentDepth = current;
			previousDepth = previous;

			OnDepthChange();
		}

		private void OnDepthChange()
		{
			if (currentDepth == 1)
			{
				decorator.Clear();
				decorator.enabled = false;

			}
			else
			{
				decorator.enabled = true;
			}

			TryResolve();
		}

		public void OnPlayerPlaced(GameObject gameObject)
		{
			position = gameObject.transform.position;
			TryResolve();
		}

		private void TryResolve()
		{
			if (waiting)
			{
				StartCoroutine(ResolveAtEndOfFrame());
			}
			else
			{
				waiting = true;
			}
		}

		private void Resolve()
		{
			waiting = false;
			CreateEntrance();
			CreateExit();
			position = default;
		}

		private void CreateEntrance()
		{
			var instance = decorator.CreateInstance(entrance, position);
			instance.name = "Entrance";
		}

		private void CreateExit()
		{
			var exitPosition = decorator.Generator.Rooms.Last().RandomItem();
			var instance = decorator.CreateInstance(exit, (Vector2)exitPosition);
			instance.name = "Exit";
		}

		private IEnumerator ResolveAtEndOfFrame()
		{
			yield return new WaitForEndOfFrame();
			Resolve();
		}
	}
}
