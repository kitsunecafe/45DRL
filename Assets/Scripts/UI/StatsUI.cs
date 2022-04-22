using JuniperJackal.Entity;
using UnityEngine;
using UnityEngine.UIElements;

namespace JuniperJackal.UI
{
	public class StatsUI : MonoBehaviour
	{
		[SerializeField] private GameObject target;
		[SerializeField] private UIDocument document;

		private ProgressBar healthbar;

		private Label nameValue;
		private Label lvValue;
		private Label strValue;
		private Label dexValue;
		private Label conValue;
		private Label intValue;
		private Label wisValue;
		private Label chaValue;

		private Label hitValue;
		private Label acValue;

#if UNITY_EDITOR
		private void Reset()
		{
			TryGetComponent(out document);
		}
#endif

		private void Awake()
		{
			var root = document.rootVisualElement;
			healthbar = root.Q<ProgressBar>("health");

			nameValue = root.Q<Label>("name-value");
			lvValue = root.Q<Label>("level-value");

			strValue = root.Q<Label>("strength-value");
			dexValue = root.Q<Label>("dexterity-value");
			conValue = root.Q<Label>("constitution-value");
			intValue = root.Q<Label>("intelligence-value");
			wisValue = root.Q<Label>("wisdom-value");
			chaValue = root.Q<Label>("charisma-value");

			hitValue = root.Q<Label>("hit-value");
			acValue = root.Q<Label>("ac-value");
		}

		public void OnCurrentHealthChanged(int value)
		{
			healthbar.value = value;
			SetHealthbarTitle();
		}

		public void OnMaxHealthChanged(int value)
		{
			healthbar.highValue = value;
			SetHealthbarTitle();
		}

		private void SetHealthbarTitle() {
			healthbar.title = $"{healthbar.value}/{healthbar.highValue}";
		}

		private static void SetStat(Label label, int value)
		{
			label.text = value.ToString();
		}

		public void OnNameChanged(string value)
		{
			nameValue.text = value;
		}

		public void OnLevelChanged(int value)
		{
			SetStat(lvValue, value);
		}

		public void OnStrengthChanged(int value)
		{
			SetStat(strValue, value);
		}

		public void OnDexterityChanged(int value)
		{
			SetStat(dexValue, value);
		}

		public void OnConstitutionChanged(int value)
		{
			SetStat(conValue, value);
		}

		public void OnIntelligenceChanged(int value)
		{
			SetStat(intValue, value);
		}

		public void OnWisdomChanged(int value)
		{
			SetStat(wisValue, value);
		}

		public void OnCharismaChanged(int value)
		{
			SetStat(chaValue, value);
		}

		public void OnHitChanged(int value)
		{
			SetStat(hitValue, value);
		}

		public void OnACChanged(int value)
		{
			SetStat(acValue, value);
		}
	}
}