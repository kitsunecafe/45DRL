namespace JuniperJackal.Entity
{
	public class IntelligenceAttribute : AbilityAttribute, INamePrefix
	{
		public override string Label => "Intelligence";
		public override string EditorDescription => "A intelligence modifier value";
		public override string Description => $"INT +{Value}";

		public string Prefix => "Astute";

		protected override Ability GetAbility(Abilities abilities)
		{
			return abilities.Intelligence;
		}
	}
}
