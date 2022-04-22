namespace JuniperJackal.Entity
{
	public class ArmorClassAttribute : IntAttribute, INameSuffix
	{
		public override string Label => "Armor Class";
		public override string EditorDescription => "The armor class of this item.";
		public override string Description => $"This item has an armor class of {Value}";

		public string Suffix => "of Redoubt";
	}
}
