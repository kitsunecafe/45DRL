using UnityEngine;

namespace JuniperJackal.Entity
{
	public class ExperienceReward : MonoBehaviour, ICombatReward
	{
		[SerializeField] private int value;
		public int Value => value;

		public void Handle(IHealthAlterant entity)
		{
			if (entity.TryGetComponent(out Advancement advancement))
			{
				advancement.AddExperience(Value);
			}
		}
	}
}
