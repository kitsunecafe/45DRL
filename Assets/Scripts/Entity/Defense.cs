using JuniperJackal.Extensions;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace JuniperJackal.Entity
{
	public class Defense : MonoBehaviour, IDamageHandler
	{
		[SerializeField] private IDamageHandler nextHandler;
		[SerializeField] private Abilities abilities;
		[SerializeField] private Equipment equipment;

		public int Priority => 1;

#if UNITY_EDITOR
		private void Reset()
		{
			nextHandler = GetNextHandler();
			TryGetComponent(out abilities);
			TryGetComponent(out equipment);
		}
#endif
		private IDamageHandler GetNextHandler()
		{
			return gameObject.GetDamageHandler(Priority - 1);
		}

		private void Awake()
		{
			if (nextHandler == null)
			{
				nextHandler = GetNextHandler();
			}
		}

		public AlterantStatus CanApply(int modifiers)
		{
			return Dice.AttackRoll(modifiers, abilities.BaseArmorClass + equipment.CurrentArmorClass());
		}

		public void Apply(IHealthAlterant source, int value)
		{
			nextHandler.Apply(source, value);
		}

		public void ApplyDamage(IDamageSource source, int value)
		{
			Apply(source, -Mathf.Abs(value));
		}
	}
}
