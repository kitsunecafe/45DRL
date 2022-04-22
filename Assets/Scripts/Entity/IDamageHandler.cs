namespace JuniperJackal.Entity
{
	public interface IDamageHandler : IHealthAlterantHandler
	{
		void ApplyDamage(IDamageSource source, int value);
	}
}
