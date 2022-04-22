namespace JuniperJackal.Entity
{
	public abstract class AbilityAttribute : ValueAttribute<int>
	{
		public override string Label => "Ability";
		public override string EditorDescription => "An ability modifier value";

		public override void ReceiveMessage<T>(T message)
		{
			if (message is EquipMessage equipMessage)
			{
				var source = equipMessage.EquipmentSource.gameObject;

				if (source.TryGetComponent<Abilities>(out var abilities))
				{
					ApplyModifier(GetAbility(abilities));
				}
			}
			else if (message is UnequipMessage unequipMessage)
			{

				var source = unequipMessage.EquipmentSource.gameObject;

				if (source.TryGetComponent<Abilities>(out var abilities))
				{
					RemoveModifier(GetAbility(abilities));
				}
			}
		}

		protected abstract Ability GetAbility(Abilities abilities);

		protected virtual void ApplyModifier(Ability ability)
		{
			ability.AddAlteration(new AbilityAlteration(Value, AblAltType.Flat, this));
		}
		protected virtual void RemoveModifier(Ability ability)
		{
			ability.RemoveAllAlterationsFromSource(this);
		}
	}
}
