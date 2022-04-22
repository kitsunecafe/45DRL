using UnityEngine;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Instancer of type `JuniperJackal.Entity.Inventory`. Inherits from `AtomEventInstancer&lt;JuniperJackal.Entity.Inventory, InventoryEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-sign-blue")]
    [AddComponentMenu("Unity Atoms/Event Instancers/Inventory Event Instancer")]
    public class InventoryEventInstancer : AtomEventInstancer<JuniperJackal.Entity.Inventory, InventoryEvent> { }
}
