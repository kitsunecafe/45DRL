namespace JuniperJackal
{
	public interface IAttribute
	{
		string Label { get; }
		string EditorDescription { get; }

		IItem Source { get; set; }

		bool AllowMultiple { get; }
		bool IsCategory { get; }
		bool Selectable { get; }

		void ReceiveMessage<T>(T message);
	}
}
