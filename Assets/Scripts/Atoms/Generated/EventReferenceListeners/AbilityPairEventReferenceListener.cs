using UnityEngine;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference Listener of type `AbilityPair`. Inherits from `AtomEventReferenceListener&lt;AbilityPair, AbilityPairEvent, AbilityPairEventReference, AbilityPairUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/AbilityPair Event Reference Listener")]
    public sealed class AbilityPairEventReferenceListener : AtomEventReferenceListener<
        AbilityPair,
        AbilityPairEvent,
        AbilityPairEventReference,
        AbilityPairUnityEvent>
    { }
}
