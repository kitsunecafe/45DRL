namespace JuniperJackal.Entity
{
	public class DexterityAttribute : AbilityAttribute, INamePrefix
	{
		public override string Label => "Dexterity";
		public override string EditorDescription => "A dexterity modifier value";
		public override string Description => $"DEX +{Value}";
		public string Prefix => "Cunning";

		protected override Ability GetAbility(Abilities abilities)
		{
			return abilities.Dexterity;
		}
	}
}
