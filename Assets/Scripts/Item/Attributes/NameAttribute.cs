namespace JuniperJackal.Entity
{
	public class NameAttribute : TextAttribute
	{
		public override string Label => "Name";
		public override string EditorDescription => "The name of this item";
		public override bool VisibleInDescription => false;
	}
}
