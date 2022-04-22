using UnityEngine;

namespace JuniperJackal.Procedural
{
	[CreateAssetMenu(fileName = "SimpleDecorator", menuName = "Roguelike/Decorators/Simple Decorator")]
	public class SimpleDecorator : ScriptableObject, IDecorator
	{
		[System.Serializable]
		public class SimpleDecoration : IDecoration
		{
			[SerializeField] private GameObject prefab;
			public GameObject Prefab => prefab;

			[SerializeField] private int minimumPerRoom;
			public int MinimumPerRoom => minimumPerRoom;

			[SerializeField] private int maximumPerRoom;
			public int MaximumPerRoom => maximumPerRoom;

	 		[SerializeField] private bool hasMaximumInstances = false;
			public bool HasMaximumInstances => hasMaximumInstances;

	 		[SerializeField] private int maximumInstances = 1;
			public int MaximumInstances => maximumInstances;
		}

		public SimpleDecoration Decoration;

		public IDecoration Create()
		{
			return Decoration;
		}
	}
}
