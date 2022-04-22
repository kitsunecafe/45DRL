using System.Collections.Generic;

namespace JuniperJackal.Entity
{
	public interface IQuery<T>
	{
		IEnumerable<T> Execute();
	}
}
