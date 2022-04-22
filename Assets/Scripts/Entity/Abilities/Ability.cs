using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace JuniperJackal.Entity
{
	[Serializable]
	public class Ability : IEquatable<Ability>, ISerializationCallbackReceiver
	{
		[SerializeField] protected IntReference baseValue;
		public virtual int BaseValue
		{
			get => baseValue.Value;
			set
			{
				if (value != baseValue.Value)
				{
					baseValue.Value = value;
				}
			}
		}

		[SerializeField] protected IntReference value;
		public int Value
		{
			get => value.Value;
			set
			{
				if (value != this.value.Value)
				{
					// Gross
					this.value.Value = value;
				}
			}
		}

		public virtual int Modifier => Mathf.FloorToInt((Value - 10) / 2);

		protected bool isDirty = true;

		protected readonly List<AbilityAlteration> alterations = new List<AbilityAlteration>();
		public ReadOnlyCollection<AbilityAlteration> Alterations { get; protected set; }

		private void OnValidate()
		{
			if (baseValue == null)
			{
				baseValue = new IntReference();
			}

			if (value == null)
			{
				value = new IntReference();
			}

			Value = CalculateFinalValue();
			Alterations = alterations.AsReadOnly();
		}

		public Ability()
		{
			if (baseValue == null)
			{
				baseValue = new IntReference();
			}

			if (value == null)
			{
				value = new IntReference();
			}

			Value = CalculateFinalValue();

			Alterations = alterations.AsReadOnly();
		}

		public Ability(int value) : this()
		{
			BaseValue = value;
			Value = CalculateFinalValue();
		}

		public virtual void AddAlteration(AbilityAlteration alteration)
		{
			// isDirty = true;
			alterations.Add(alteration);
			alterations.Sort(CompareAlterationOrder);
			Value = CalculateFinalValue();
		}

		protected virtual int CompareAlterationOrder(AbilityAlteration a, AbilityAlteration b)
		{
			if (a.Order < b.Order) return -1;
			else if (a.Order < b.Order) return 1;
			else return 0;
		}

		public virtual bool RemoveAlteration(AbilityAlteration alteration)
		{
			var removed = alterations.Remove(alteration);

			if (removed)
			{
				// isDirty = true;
				Value = CalculateFinalValue();
			}

			return removed;
		}

		public virtual bool RemoveAllAlterationsFromSource(object source)
		{
			var modified = false;

			for (int i = alterations.Count - 1; i >= 0; i--)
			{
				if (alterations[i].Source == source)
				{
					modified = true;
					alterations.RemoveAt(i);
				}
			}

			if (modified)
			{
				// isDirty = true;
				Value = CalculateFinalValue();
			}

			return modified;
		}

		protected virtual int CalculateFinalValue()
		{
			float value = BaseValue;
			float additiveSum = 0;

			for (int i = 0; i < alterations.Count; i++)
			{
				var alt = alterations[i];

				switch (alt.Type)
				{
					case AblAltType.Flat:
						value += alt.Value;
						break;
					case AblAltType.PercentAdd:
						additiveSum += alt.Value;

						if (i + 1 >= alterations.Count || alterations[i + 1].Type != AblAltType.PercentAdd)
						{
							value *= 1 + additiveSum;
							additiveSum = 0;
						}

						break;
					case AblAltType.PercentMult:
						value *= 1 * alt.Value;
						break;
				}
			}

			return Mathf.RoundToInt(value);
		}

		public bool Equals(Ability ability)
		{
			return baseValue == ability.baseValue &&
						 BaseValue == ability.BaseValue &&
						 Value == ability.Value &&
						 Modifier == ability.Modifier &&
						 isDirty == ability.isDirty &&
						 value == ability.value &&
						 EqualityComparer<List<AbilityAlteration>>.Default.Equals(alterations, ability.alterations) &&
						 EqualityComparer<ReadOnlyCollection<AbilityAlteration>>.Default.Equals(Alterations, ability.Alterations);
		}

		public void OnBeforeSerialize() => this.OnValidate();

		public void OnAfterDeserialize() { }
	}
}
