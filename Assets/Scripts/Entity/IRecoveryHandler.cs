namespace JuniperJackal.Entity
{
	public interface IRecoveryHandler : IHealthAlterantHandler
	{
		void ApplyRecovery(IRecoverySource source, int value);
	}
}
