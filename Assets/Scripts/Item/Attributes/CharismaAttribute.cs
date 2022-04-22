namespace JuniperJackal.Entity
{
	public class CharismaAttribute : AbilityAttribute, INamePrefix
	{
		public override string Label => "Charisma";
		public override string EditorDescription => "A charisma modifier value";
		public override string Description => $"CHA +{Value}";

		public string Prefix => "Smooth";

		protected override Ability GetAbility(Abilities abilities)
		{
			return abilities.Charisma;
		}
	}
}
