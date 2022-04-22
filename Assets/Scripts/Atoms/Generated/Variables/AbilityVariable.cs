using UnityEngine;
using System;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Variable of type `JuniperJackal.Entity.Ability`. Inherits from `AtomVariable&lt;JuniperJackal.Entity.Ability, AbilityPair, AbilityEvent, AbilityPairEvent, AbilityAbilityFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-lush")]
    [CreateAssetMenu(menuName = "Unity Atoms/Variables/Ability", fileName = "AbilityVariable")]
    public sealed class AbilityVariable : AtomVariable<JuniperJackal.Entity.Ability, AbilityPair, AbilityEvent, AbilityPairEvent, AbilityAbilityFunction>
    {
        protected override bool ValueEquals(JuniperJackal.Entity.Ability other)
        {
            throw new NotImplementedException();
        }
    }
}
