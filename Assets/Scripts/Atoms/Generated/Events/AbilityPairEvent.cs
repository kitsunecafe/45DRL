using UnityEngine;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event of type `AbilityPair`. Inherits from `AtomEvent&lt;AbilityPair&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/AbilityPair", fileName = "AbilityPairEvent")]
    public sealed class AbilityPairEvent : AtomEvent<AbilityPair>
    {
    }
}
