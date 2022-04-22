using System;
using System.Collections.Generic;

namespace JuniperJackal
{
	public interface IDescriptor<T>
	{
		Guid Guid { get; }
		T Value { get; }
	}

	public interface IRegistry<T>
	{
		IEnumerable<T> Items { get; }
	}
}
