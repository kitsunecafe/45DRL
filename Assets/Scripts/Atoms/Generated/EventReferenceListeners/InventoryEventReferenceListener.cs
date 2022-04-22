using UnityEngine;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference Listener of type `JuniperJackal.Entity.Inventory`. Inherits from `AtomEventReferenceListener&lt;JuniperJackal.Entity.Inventory, InventoryEvent, InventoryEventReference, InventoryUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/Inventory Event Reference Listener")]
    public sealed class InventoryEventReferenceListener : AtomEventReferenceListener<
        JuniperJackal.Entity.Inventory,
        InventoryEvent,
        InventoryEventReference,
        InventoryUnityEvent>
    { }
}
