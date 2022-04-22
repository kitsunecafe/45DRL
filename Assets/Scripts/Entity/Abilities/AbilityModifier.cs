using UnityEngine;

namespace JuniperJackal.Entity
{
	public enum AblAltType
	{
		Flat,
		PercentAdd,
		PercentMult
	}

	public class AbilityAlteration
	{
		public readonly float Value;
		public readonly AblAltType Type;
		public int Order;
		public readonly object Source;

		public AbilityAlteration(float value, AblAltType type) : this(value, type, (int)type, null) { }
		public AbilityAlteration(float value, AblAltType type, int order) : this(value, type, order, null) { }
		public AbilityAlteration(float value, AblAltType type, object source) : this(value, type, (int) type, source) { }
		public AbilityAlteration(float value, AblAltType type, int order, object source)
		{
			Value = value;
			Type = type;
			Order = order;
			Source = source;
		}
	}
}
