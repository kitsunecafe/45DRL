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
	public class PrefabDecorator : MonoBehaviour
	{
		[SerializeField] private AbstractMapGenerator generator;
		[SerializeField] private Tilemap tilemap;

		[SerializeField] private GameObject prefab;
		public GameObject Prefab {
			get => prefab;
			set {
				if (prefab != value) {
					prefab = value;
					Clear();
				}
			}
		}

		public Transform Parent;
		[SerializeField] private bool hasMaximum = false;
		[SerializeField] private int maxInstances = 5;
		[SerializeField, Range(0.1f, 1f)]
		private float chance = 0.5f;
		[SerializeField] private bool skipStartingRoom = true;
		[SerializeField] private bool clearOnRegenerate = true;
		[SerializeField] private UnityEvent<GameObject> placedObject;

		private List<GameObject> entities = new List<GameObject>();

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

		private void Decorate()
		{
			List<GameObject> entitiesToPlace;

			if (clearOnRegenerate)
			{
				Clear();
				entitiesToPlace = new List<GameObject>();
			}
			else
			{
				entitiesToPlace = new List<GameObject>(entities);
				entities.Clear();
			}

			var rooms = generator.Rooms.Skip(skipStartingRoom ? 0 : 1).ToList();

			foreach (var room in rooms)
			{
				if (Random.value < chance)
				{
					var position = room.RandomItem();
					PlaceAt((Vector2)position, entitiesToPlace);

					if (hasMaximum && entities.Count >= maxInstances)
					{
						break;
					}
				}
			}

			Clear(entitiesToPlace);
		}

		private GameObject GetEntity(Vector2 position, List<GameObject> entities)
		{
			if (entities.Count > 0)
			{
				var entity = entities[0];
				entities.RemoveAt(0);
				entity.transform.position = position;

				return entity;
			}
			else
			{
				return Instantiate(Prefab, position, Quaternion.identity, Parent);
			}
		}

		public void Clear()
		{
			Clear(entities);
		}

		public static void Clear(List<GameObject> entities)
		{
			for (int i = 0; i < entities.Count; i++)
			{
				Destroy(entities[i]);
			}

			entities.Clear();
		}

		public void PlaceAt(GameObject obj) => PlaceAt(obj.transform.position);
		public void PlaceAt(Vector3 position) => PlaceAt(position, entities);
		public void PlaceAt(Vector3 position, List<GameObject> entitiesToPlace)
		{
			var entity = GetEntity(position, entitiesToPlace);

			entities.Add(entity);
			placedObject?.Invoke(entity);
		}

		private static bool IsPrefab(GameObject gameObject)
		{
			return gameObject.scene == default;
		}
	}
}
