namespace JuniperJackal.Entity
{
	public class StrengthAttribute : AbilityAttribute, INamePrefix
	{
		public override string Label => "Strength";
		public override string EditorDescription => "A strength modifier value";
		public override string Description => $"STR +{Value}";

		public string Prefix => "Sharp";

		protected override Ability GetAbility(Abilities abilities)
		{
			return abilities.Strength;
		}
	}
}
