using UnityEngine;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference Listener of type `ItemPair`. Inherits from `AtomEventReferenceListener&lt;ItemPair, ItemPairEvent, ItemPairEventReference, ItemPairUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/ItemPair Event Reference Listener")]
    public sealed class ItemPairEventReferenceListener : AtomEventReferenceListener<
        ItemPair,
        ItemPairEvent,
        ItemPairEventReference,
        ItemPairUnityEvent>
    { }
}
