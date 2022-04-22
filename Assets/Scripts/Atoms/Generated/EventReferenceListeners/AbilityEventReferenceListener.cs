using UnityEngine;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference Listener of type `JuniperJackal.Entity.Ability`. Inherits from `AtomEventReferenceListener&lt;JuniperJackal.Entity.Ability, AbilityEvent, AbilityEventReference, AbilityUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/Ability Event Reference Listener")]
    public sealed class AbilityEventReferenceListener : AtomEventReferenceListener<
        JuniperJackal.Entity.Ability,
        AbilityEvent,
        AbilityEventReference,
        AbilityUnityEvent>
    { }
}
