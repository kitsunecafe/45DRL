using UnityEngine;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Instancer of type `ItemPair`. Inherits from `AtomEventInstancer&lt;ItemPair, ItemPairEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-sign-blue")]
    [AddComponentMenu("Unity Atoms/Event Instancers/ItemPair Event Instancer")]
    public class ItemPairEventInstancer : AtomEventInstancer<ItemPair, ItemPairEvent> { }
}
