namespace JuniperJackal.Entity
{
	public abstract class IntAttribute : ValueAttribute<int>
	{
		public override string Label => "Integer";
		public override string EditorDescription => "An integer value";
	}
}
