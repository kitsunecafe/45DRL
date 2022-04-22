using UnityEngine;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Value List of type `JuniperJackal.Entity.Inventory`. Inherits from `AtomValueList&lt;JuniperJackal.Entity.Inventory, InventoryEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-piglet")]
    [CreateAssetMenu(menuName = "Unity Atoms/Value Lists/Inventory", fileName = "InventoryValueList")]
    public sealed class InventoryValueList : AtomValueList<JuniperJackal.Entity.Inventory, InventoryEvent> { }
}
