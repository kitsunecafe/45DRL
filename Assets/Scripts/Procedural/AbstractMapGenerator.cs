using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;

namespace JuniperJackal.Procedural
{
	public abstract class AbstractMapGenerator : MonoBehaviour
	{
		[SerializeField] protected TileMapInterpreter interpreter;
		[SerializeField] protected Vector2Int startPosition = default;
		[SerializeField] protected bool generateOnStart = false;
		[SerializeField] protected UnityEvent generationStarted;
		[SerializeField] protected UnityEvent generated;
		[HideInInspector] public bool IsGenerating { get; private set; } = false;

		public HashSet<Vector2Int> Walls { get; protected set; } = new HashSet<Vector2Int>();
		public HashSet<Vector2Int> Floor { get; protected set; } = new HashSet<Vector2Int>();
		public List<List<Vector2Int>> Rooms { get; protected set; } = new List<List<Vector2Int>>();

#if UNITY_EDITOR
		[SerializeField] private bool debug = false;
		private List<Bounds> roomBounds = new List<Bounds>();
#endif

		private void Start()
		{
			if (generateOnStart)
			{
				Generate();
			}
		}

		public void Generate()
		{
			interpreter.Clear();

			generationStarted?.Invoke();

			IsGenerating = true;
			Execute();
			IsGenerating = false;

#if UNITY_EDITOR
			if (debug)
			{
				GenerateBounds();
			}
#endif

			// generated?.Invoke();
			StartCoroutine(DelayedEvent(generated));
		}

		protected abstract void Execute();

		private IEnumerator DelayedEvent(UnityEvent evt)
		{
			yield return null;
			evt?.Invoke();
		}

#if UNITY_EDITOR
		private void GenerateBounds()
		{
			roomBounds.Clear();
			foreach (var room in Rooms)
			{
				var bounds = new Bounds();
				foreach (var position in room)
				{
					bounds.Encapsulate((Vector2)position);
				}
				roomBounds.Add(bounds);
			}
		}

		private void OnDrawGizmosSelected()
		{
			if (debug)
			{
				Gizmos.color = Color.green;
				foreach (var bounds in roomBounds)
				{
					Gizmos.DrawWireCube(bounds.center, bounds.size);
				}
			}
		}
#endif

	}
}
