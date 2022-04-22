using UnityEngine;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference Listener of type `JuniperJackal.Entity.Item`. Inherits from `AtomEventReferenceListener&lt;JuniperJackal.Entity.Item, ItemEvent, ItemEventReference, ItemUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/Item Event Reference Listener")]
    public sealed class ItemEventReferenceListener : AtomEventReferenceListener<
        JuniperJackal.Entity.Item,
        ItemEvent,
        ItemEventReference,
        ItemUnityEvent>
    { }
}
