using UnityEngine;
using UnityAtoms.BaseAtoms;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Set variable value Action of type `JuniperJackal.Entity.Ability`. Inherits from `SetVariableValue&lt;JuniperJackal.Entity.Ability, AbilityPair, AbilityVariable, AbilityConstant, AbilityReference, AbilityEvent, AbilityPairEvent, AbilityVariableInstancer&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-purple")]
    [CreateAssetMenu(menuName = "Unity Atoms/Actions/Set Variable Value/Ability", fileName = "SetAbilityVariableValue")]
    public sealed class SetAbilityVariableValue : SetVariableValue<
        JuniperJackal.Entity.Ability,
        AbilityPair,
        AbilityVariable,
        AbilityConstant,
        AbilityReference,
        AbilityEvent,
        AbilityPairEvent,
        AbilityAbilityFunction,
        AbilityVariableInstancer>
    { }
}
