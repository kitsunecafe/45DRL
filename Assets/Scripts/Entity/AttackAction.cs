using System.Linq;
using JuniperJackal.Extensions;
using UnityAtoms.BaseAtoms;
using UnityAtoms.Tags;
using UnityEngine;
using UnityEngine.Events;

namespace JuniperJackal.Entity
{
	[System.Serializable]
	public class AttackData
	{
		public GameObject Attacker;
		public GameObject Defender;
		public Item Weapon;
		public AlterantStatus Status;

		public AttackData(GameObject attacker, GameObject defender, Item weapon, AlterantStatus status)
		{
			Attacker = attacker;
			Defender = defender;
			Weapon = weapon;
			Status = status;
		}
	}

	public class AttackAction : EntityAction, IDamageSource
	{
		[SerializeField] private Abilities abilities;
		[SerializeField] private Equipment equipment;
		[SerializeField] private StringConstant attackTag;
		[SerializeField] private UnityEvent<AttackData> Attacked;

		private new string name;

#if UNITY_EDITOR
		private void Reset()
		{
			TryGetComponent(out abilities);
			TryGetComponent(out equipment);
		}
#endif

		private void Awake()
		{
			name = gameObject.GetName();
		}

		public override bool WantsToExecute() => entity.NextHit.collider?.gameObject.HasTag(attackTag) ?? false;
		public override void Execute()
		{
			var damageHandler = entity.NextHit.collider.gameObject.GetDamageHandler();
			if (damageHandler != null)
			{
				foreach (var weapon in equipment.Weapons)
				{
					Attack(damageHandler, weapon);
				}
			}

			entity.FinishTurn();
		}

		private void Attack(IDamageHandler target, Item item)
		{
			var modifier = abilities.AbilityModifier(item);
			var status = target.CanApply(modifier);
			Attacked?.Invoke(new AttackData(gameObject, entity.NextHit.transform.gameObject, item, status));

			if (status != AlterantStatus.Miss)
			{
				var multiplier = status == AlterantStatus.Critical ? 2 : 1;
				var damage = (equipment.RollForDamage() * multiplier) + modifier;

				target.ApplyDamage(this, damage);
			}
		}
	}
}
