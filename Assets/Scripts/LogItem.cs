using JuniperJackal.Entity;
using JuniperJackal.Extensions;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Localization;

namespace JuniperJackal
{
	public class LogItem : MonoBehaviour
	{
		[SerializeField] private LocalizedString acquiredItem;
		[SerializeField] private LocalizedString acquiredNothing;
		[SerializeField] private StringEvent logEvent;

		public void Log(Item item)
		{
			logEvent?.Raise(GetMessage(item));
		}

		private string GetMessage(Item item)
		{
			if (item == null || item == Item.None)
			{
				return acquiredNothing.GetLocalizedString();
			}
			else
			{
				return acquiredItem.GetLocalizedString(new { Item = item.GetName() });
			}
		}
	}
}