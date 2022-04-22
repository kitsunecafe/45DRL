using UnityEngine;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event of type `JuniperJackal.Entity.Ability`. Inherits from `AtomEvent&lt;JuniperJackal.Entity.Ability&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/Ability", fileName = "AbilityEvent")]
    public sealed class AbilityEvent : AtomEvent<JuniperJackal.Entity.Ability>
    {
    }
}
