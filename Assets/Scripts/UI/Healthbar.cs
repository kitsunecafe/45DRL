using UnityEngine;
using UnityEngine.UI;

namespace JuniperJackal.UI
{
	public class Healthbar : MonoBehaviour
	{
		[SerializeField] private Slider slider;

		private void Start()
		{
			slider.minValue = 0;
		}

		public void OnCurrentHealthChanged(int value)
		{
			slider.value = value;
		}

		public void OnMaxHealthChanged(int value)
		{
			slider.maxValue = value;
		}
	}
}
