using System;
using UnityAtoms.BaseAtoms;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Reference of type `JuniperJackal.Entity.Ability`. Inherits from `AtomReference&lt;JuniperJackal.Entity.Ability, AbilityPair, AbilityConstant, AbilityVariable, AbilityEvent, AbilityPairEvent, AbilityAbilityFunction, AbilityVariableInstancer, AtomCollection, AtomList&gt;`.
    /// </summary>
    [Serializable]
    public sealed class AbilityReference : AtomReference<
        JuniperJackal.Entity.Ability,
        AbilityPair,
        AbilityConstant,
        AbilityVariable,
        AbilityEvent,
        AbilityPairEvent,
        AbilityAbilityFunction,
        AbilityVariableInstancer>, IEquatable<AbilityReference>
    {
        public AbilityReference() : base() { }
        public AbilityReference(JuniperJackal.Entity.Ability value) : base(value) { }
        public bool Equals(AbilityReference other) { return base.Equals(other); }
        protected override bool ValueEquals(JuniperJackal.Entity.Ability other)
        {
            throw new NotImplementedException();
        }
    }
}
