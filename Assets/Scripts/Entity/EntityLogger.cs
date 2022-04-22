using JuniperJackal.Extensions;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Tables;

namespace JuniperJackal.Entity
{
	public class EntityLogger : MonoBehaviour
	{
		[SerializeField] private LocalizedString attack;
		[SerializeField] private LocalizedString critical;
		[SerializeField] private LocalizedString wait;
		[SerializeField] private LocalizedString waitCancelled;
		[SerializeField] private LocalizedString recover;
		[SerializeField] private LocalizedString damage;
		[SerializeField] private LocalizedString miss;
		[SerializeField] private LocalizedString die;

		[SerializeField] protected LocalizedStringTable stringTable = default;
		[SerializeField] protected StringEvent logEvent = default;
		protected StringTable currentTable = default;

		private void Start()
		{
			stringTable.GetTableAsync().Completed += (table) => currentTable = table.Result;
		}

		public void OnAttack(AttackData data)
		{
			var stringData = new
			{
				Attacker = data.Attacker.GetName(),
				Defender = data.Defender.GetName(),
				Weapon = data.Weapon.GetName()
			};

			var value = attack.GetLocalizedString(stringData);

			logEvent?.Raise(value);

			var additionalData = GetAttackString(data.Status)?.GetLocalizedString(stringData);

			if (additionalData != null)
			{
				logEvent?.Raise(additionalData);
			}
		}

		private LocalizedString GetAttackString(AlterantStatus status)
		{
			switch (status)
			{
				case AlterantStatus.Miss: return miss;
				case AlterantStatus.Critical: return critical;
				default: return null;
			}
		}

		public void OnWait()
		{
			logEvent?.Raise(wait.GetLocalizedString(new
			{
				Entity = gameObject.GetName()
			}));
		}

		public void OnWaitCancelled()
		{
			logEvent?.Raise(waitCancelled.GetLocalizedString());
		}

		public void OnHealthChange(IntPair value)
		{
			var difference = value.Item1 - value.Item2;
			var str = difference > 0 ? recover : damage;

			logEvent?.Raise(str.GetLocalizedString(new
			{
				Entity = gameObject.GetName(),
				Value = Mathf.Abs(difference).ToString()
			}));
		}

		public void OnDie()
		{
			logEvent?.Raise(die.GetLocalizedString(new { Entity = gameObject.GetName() }));
		}
	}
}
