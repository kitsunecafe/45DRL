using UnityEngine;


namespace JuniperJackal
{
	public abstract class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
	{
		private static T instance;
		public static T Instance
		{
			get
			{
				if (instance == null)
				{
					instance = CreateInstance<T>();
					(instance as SingletonScriptableObject<T>).OnInitialize();
				}
				return instance;
			}
		}

		protected virtual void OnInitialize() { }
	}
}
