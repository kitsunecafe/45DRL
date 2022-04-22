namespace JuniperJackal.Entity
{
	public class WisdomAttribute : AbilityAttribute, INamePrefix
	{
		public override string Label => "Wisdom";
		public override string EditorDescription => "A wisdom modifier value";
		public override string Description => $"WIS +{Value}";

		public string Prefix => "Sage";

		protected override Ability GetAbility(Abilities abilities)
		{
			return abilities.Wisdom;
		}
	}
}
