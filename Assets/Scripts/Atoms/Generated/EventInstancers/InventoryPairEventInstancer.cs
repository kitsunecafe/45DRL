using UnityEngine;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Instancer of type `InventoryPair`. Inherits from `AtomEventInstancer&lt;InventoryPair, InventoryPairEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-sign-blue")]
    [AddComponentMenu("Unity Atoms/Event Instancers/InventoryPair Event Instancer")]
    public class InventoryPairEventInstancer : AtomEventInstancer<InventoryPair, InventoryPairEvent> { }
}
