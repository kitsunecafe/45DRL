namespace JuniperJackal.Entity
{
	public interface IHealthAlterant
	{
		bool TryGetComponent<T>(out T component);
	}
}
