using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace JuniperJackal
{
	public class Logger : MonoBehaviour
	{
		[SerializeField] private int maxLines = 10;
		[SerializeField] private StringValueList messages;

		public void MessageAdded(string message)
		{
			if (messages.Count > maxLines)
			{
				messages.RemoveAt(0);
			}

			messages.Add(message);
		}
	}
}
