using System;
using System.Collections.Generic;
using System.Linq;
using JuniperJackal.Extensions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

namespace JuniperJackal.Procedural
{
	public class Decorator : MonoBehaviour
	{
		[SerializeField] private AbstractMapGenerator generator;
		public AbstractMapGenerator Generator => generator;
		[SerializeField] private Tilemap tilemap;

		[RequireInterface(typeof(IDecorator))]
		[SerializeField] private UnityEngine.Object _decorator;
		private IDecorator decorator => _decorator as IDecorator;

		public Transform Parent;

		[SerializeField, Range(0.1f, 1f)]
		private float chance = 0.5f;
		[SerializeField] private bool skipStartingRoom = true;
		[SerializeField] private UnityEvent<GameObject> placedObject;

		private List<GameObject> entities = new List<GameObject>();
		private IDictionary<GameObject, int> placedCounts = new Dictionary<GameObject, int>();

#if UNITY_EDITOR
		private void Reset()
		{
			Parent = transform;
		}
#endif

		public void OnGenerate()
		{
			Decorate();
		}

		public void Clear()
		{
			for (int i = 0; i < entities.Count; i++)
			{
				Destroy(entities[i]);
			}

			entities.Clear();
			placedCounts.Clear();
		}

		private void Decorate()
		{
			if (enabled == false)
			{
				return;
			}

			Clear();

			var rooms = generator.Rooms.Skip(skipStartingRoom ? 0 : 1).ToList();

			for (int i = 0; i < rooms.Count; i++)
			{
				if (Random.value < chance)
				{
					var decoration = decorator.Create();
					var max = MaximumAllowedInstances(decoration);

					if (max == 0) continue;

					var instances = Random.Range(decoration.MinimumPerRoom, max + 1);

					CreateInstances(decoration.Prefab, max, rooms[i]);
				}
			}
		}

		private int MaximumAllowedInstances(IDecoration decoration)
		{
			if (decoration.HasMaximumInstances && placedCounts.TryGetValue(decoration.Prefab, out int count))
			{
				return Mathf.Min(decoration.MaximumPerRoom, decoration.MaximumInstances - count);
			}

			return decoration.MaximumPerRoom;
		}

		private GameObject CreateInstanceWithoutCount(GameObject prefab, Vector3 position)
		{
			var entity = Instantiate(prefab, position, Quaternion.identity, Parent);
			entities.Add(entity);
			placedObject?.Invoke(entity);
			return entity;
		}

		private List<GameObject> CreateInstances(GameObject prefab, int count, List<Vector3> positions)
		{
			IncreaseCount(prefab, count);
			var instances = new List<GameObject>(count);

			for (int i = 0; i < count; i++)
			{
				var position = positions.RandomItem();
				instances.Add(CreateInstanceWithoutCount(prefab, (Vector2)position));
			}

			return instances;
		}

		public GameObject CreateInstance(GameObject prefab, Vector3 position)
		{
			IncreaseCount(prefab, 1);
			return CreateInstanceWithoutCount(prefab, position);
		}

		public List<GameObject> CreateInstances(GameObject prefab, int count, List<Vector2Int> positions)
		{
			return CreateInstances(
				prefab,
				count,
				positions.Select(v2i => new Vector3(v2i.x, v2i.y, 0)).ToList());
		}

		private void IncreaseCount(GameObject prefab, int count)
		{
			if (placedCounts.TryGetValue(prefab, out int value))
			{
				placedCounts[prefab] += count;
			}
			else
			{
				placedCounts[prefab] = count;
			}
		}
	}
}
