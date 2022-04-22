using System.Text;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;

namespace JuniperJackal.UI
{
	public class Output : MonoBehaviour
	{
		[SerializeField] private int initialCapacity = 10;
		[SerializeField] private StringValueList messages;
		[SerializeField] private UnityEvent<string> MessageArrived;

		public void OnMessage(string message)
		{
			var builder = new StringBuilder(initialCapacity);

			for (int i = 0; i < messages.Count; i++)
			{
				builder.AppendLine(messages[i]);
			}

			MessageArrived?.Invoke(builder.ToString());
		}
	}
}