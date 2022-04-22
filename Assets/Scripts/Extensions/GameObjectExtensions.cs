using System.Linq;
using JuniperJackal.Entity;
using UnityEngine;

namespace JuniperJackal.Extensions
{
	public static class TransformExtensions
	{
		public static void DestroyChildren(this Transform transform)
		{
			for (int i = 0; i < transform.childCount; i++)
			{
				GameObject.Destroy(transform.GetChild(i).gameObject);
			}
		}
	}

	public static class GameObjectExtensions
	{
		public static void DestroyChildren(this GameObject gameObject)
		{
			gameObject.transform.DestroyChildren();
		}

		public static T GetHealthAlterantHandler<T>(this GameObject gameObject) where T : IHealthAlterantHandler
		{
			return gameObject.GetComponents<T>().OrderByDescending(handler => handler.Priority).First();
		}

		public static T GetHealthAlterantHandler<T>(this GameObject gameObject, int priority) where T : IHealthAlterantHandler
		{
			return gameObject.GetComponents<T>().Where(handler => handler.Priority == priority).First();
		}

		public static IRecoveryHandler GetRecoveryHandler(this GameObject gameObject)
		{
			return GetHealthAlterantHandler<IRecoveryHandler>(gameObject);
		}

		public static IRecoveryHandler GetRecoveryHandler(this GameObject gameObject, int priority)
		{
			return GetHealthAlterantHandler<IRecoveryHandler>(gameObject, priority);
		}

		public static IDamageHandler GetDamageHandler(this GameObject gameObject)
		{
			return GetHealthAlterantHandler<IDamageHandler>(gameObject);
		}

		public static IDamageHandler GetDamageHandler(this GameObject gameObject, int priority)
		{
			return GetHealthAlterantHandler<IDamageHandler>(gameObject, priority);
		}

		public static string GetName(this GameObject gameObject)
		{
			return gameObject.TryGetComponent<Name>(out var name) ? name.Value : gameObject.name;
		}

		public static bool IsPrefab(this GameObject gameObject)
		{
			return gameObject.scene == null;
		}
	}
}
