using UnityEngine;
using UnityAtoms.BaseAtoms;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Variable Instancer of type `JuniperJackal.Entity.Ability`. Inherits from `AtomVariableInstancer&lt;AbilityVariable, AbilityPair, JuniperJackal.Entity.Ability, AbilityEvent, AbilityPairEvent, AbilityAbilityFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-hotpink")]
    [AddComponentMenu("Unity Atoms/Variable Instancers/Ability Variable Instancer")]
    public class AbilityVariableInstancer : AtomVariableInstancer<
        AbilityVariable,
        AbilityPair,
        JuniperJackal.Entity.Ability,
        AbilityEvent,
        AbilityPairEvent,
        AbilityAbilityFunction>
    { }
}
