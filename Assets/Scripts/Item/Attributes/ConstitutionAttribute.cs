namespace JuniperJackal.Entity
{
	public class ConstitutionAttribute : AbilityAttribute, INamePrefix
	{
		public override string Label => "Constitution";
		public override string EditorDescription => "A constitution modifier value";
		public override string Description => $"CON +{Value}";

		public string Prefix => "Durable";

		protected override Ability GetAbility(Abilities abilities)
		{
			return abilities.Constitution;
		}
	}
}
