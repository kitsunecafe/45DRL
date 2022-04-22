using UnityEngine;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference Listener of type `InventoryPair`. Inherits from `AtomEventReferenceListener&lt;InventoryPair, InventoryPairEvent, InventoryPairEventReference, InventoryPairUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/InventoryPair Event Reference Listener")]
    public sealed class InventoryPairEventReferenceListener : AtomEventReferenceListener<
        InventoryPair,
        InventoryPairEvent,
        InventoryPairEventReference,
        InventoryPairUnityEvent>
    { }
}
