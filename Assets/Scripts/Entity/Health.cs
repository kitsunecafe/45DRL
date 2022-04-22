using JuniperJackal.Extensions;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;

namespace JuniperJackal.Entity
{
	public class Health : MonoBehaviour, IDamageHandler, IRecoveryHandler
	{
		[SerializeField] private Ability maxHealth = new Ability(10);
		public int MaxHealth => maxHealth.Value;

		[SerializeField] private IntReference currentHealth = default;
		public int CurrentHealth => currentHealth.Value;

		[SerializeField] private Abilities abilities = default;

		[SerializeField] private UnityEvent<IntPair> Healed = default;
		[SerializeField] private UnityEvent<IntPair> Damaged = default;
		[SerializeField] private UnityEvent<IHealthAlterant> Died = default;

		public int Priority => 0;

		private new string name;

#if UNITY_EDITOR
		private void Reset()
		{
			TryGetComponent(out abilities);
		}
#endif

		private void Awake()
		{
			name = gameObject.GetName();
			maxHealth.AddAlteration(new AbilityAlteration(abilities.Dexterity.Value, AblAltType.Flat));
			currentHealth.Value = MaxHealth;
		}

		public AlterantStatus CanApply(int modifiers)
		{
			return Dice.AttackRoll(modifiers, abilities.BaseArmorClass);
		}

		public void Apply(IHealthAlterant source, int value)
		{
			if (value == 0 || (IsDead() && value < 0) || (HasMaxHealth() && value > 0))
			{
				return;
			}

			var evt = value > 0 ? Healed : Damaged;
			var oldValue = currentHealth.Value;
			var newValue = Mathf.Clamp(oldValue + value, 0, MaxHealth);

			currentHealth.Value = newValue;

			var pair = new IntPair();
			pair.Item1 = newValue;
			pair.Item2 = oldValue;

			evt?.Invoke(pair);

			if (IsDead())
			{
				Died?.Invoke(source);
			}
		}

		public bool HasMaxHealth() => MaxHealth == CurrentHealth;
		public bool IsDead() => CurrentHealth <= 0;

		public void ApplyRecovery(IRecoverySource source, int value)
		{
			Apply(source, Mathf.Abs(value));
		}

		public void ApplyDamage(IDamageSource source, int value)
		{
			Apply(source, -Mathf.Abs(value));
		}
	}
}
