using UnityEngine;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Value List of type `JuniperJackal.Entity.Ability`. Inherits from `AtomValueList&lt;JuniperJackal.Entity.Ability, AbilityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-piglet")]
    [CreateAssetMenu(menuName = "Unity Atoms/Value Lists/Ability", fileName = "AbilityValueList")]
    public sealed class AbilityValueList : AtomValueList<JuniperJackal.Entity.Ability, AbilityEvent> { }
}
