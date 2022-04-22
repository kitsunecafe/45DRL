namespace JuniperJackal.Entity
{
	public class StackableAttribute : IntAttribute
	{
		public override string Label => "Stack Max";
		public override string EditorDescription => "How much this item can stack until a new stack is required";
	}
}
