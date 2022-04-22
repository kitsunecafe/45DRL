using UnityEngine;

namespace JuniperJackal.Entity
{
	public class DamageAttribute : TextAttribute, INameSuffix
	{
		public override string Label => "Damage";
		public override string EditorDescription => "The damage to apply during combat.";
		public override string Description => $"This item deals {dice.ToString()} damage.";
		private Dice dice = default;

		[HideInInspector]
		public Dice Dice
		{
			get => dice;
			set
			{
				if (value != dice)
				{
					dice = value;
					Value = dice.ToString();
				}
			}
		}

		public string Suffix => "of Might";

		private void Awake()
		{
			OnValidate();
		}

		private void OnEnable()
		{
			OnValidate();
		}

		private void OnValidate()
		{
			if (Value != null && Value.Trim() != null)
			{
				Dice = Dice.FromString(Value);
			}
		}
	}
}
