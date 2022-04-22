namespace JuniperJackal.Entity
{
	public class ItemProperty : ItemAttribute
	{
		public override string Label => "Property";
		public override string EditorDescription => "An item property";
		public override bool AllowMultiple => false;
	}
}
