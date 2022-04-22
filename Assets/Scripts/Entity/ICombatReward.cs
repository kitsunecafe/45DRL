using UnityEngine;

namespace JuniperJackal.Entity
{
	public interface ICombatReward
	{
		void Handle(IHealthAlterant entity);
	}
}
