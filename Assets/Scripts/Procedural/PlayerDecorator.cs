using System.Linq;
using JuniperJackal.Extensions;
using UnityEngine;
using UnityEngine.Events;

namespace JuniperJackal.Procedural
{
	public class PlayerDecorator : MonoBehaviour
	{
		[SerializeField] private AbstractMapGenerator generator;

		[SerializeField, RequireInterface(typeof(IDecorator))]
		private Object _decorator;
		private IDecorator decorator;

		[SerializeField] private Transform parent;
		[SerializeField] private UnityEvent<GameObject> placed;

		private GameObject instance;

		private void OnValidate()
		{
			decorator = _decorator as IDecorator;
		}

		private void Awake()
		{
			OnValidate();
		}

		public void Decorate()
		{
			var playerInstance = PlayerInstance();
			var position = generator.Rooms.First().RandomItem();
			playerInstance.transform.position = (Vector2)position;
			placed?.Invoke(playerInstance);
		}

		private GameObject PlayerInstance()
		{
			if (instance)
			{
				return instance;
			}
			else
			{
				return instance = Instantiate(decorator.Create().Prefab, parent);
			}
		}
	}
}
