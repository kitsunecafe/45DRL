using UnityEngine;

namespace JuniperJackal.Procedural
{
	public interface IDecorator
	{
		IDecoration Create();
	}

	public interface IDecoration
	{
		GameObject Prefab { get; }
		int MinimumPerRoom { get; }
		int MaximumPerRoom { get; }
		bool HasMaximumInstances { get; }
		int MaximumInstances { get; }
	}
}
