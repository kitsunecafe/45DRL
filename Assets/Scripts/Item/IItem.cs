using System.Collections.Generic;

namespace JuniperJackal
{
	public interface IItem
	{
		List<IAttribute> Attributes { get; set; }
		void ReceiveMessage<T>(T message);
	}
}
