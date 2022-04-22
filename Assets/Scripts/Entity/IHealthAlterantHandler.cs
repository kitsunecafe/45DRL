namespace JuniperJackal.Entity
{
	public enum AlterantStatus { Miss, Hit, Critical }
	public interface IHealthAlterantHandler
	{
		int Priority { get; }
		AlterantStatus CanApply(int modifiers);
		void Apply(IHealthAlterant source, int value);
	}
}
