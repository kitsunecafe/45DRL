using UnityEngine;
using UnityAtoms.BaseAtoms;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Variable Instancer of type `JuniperJackal.Entity.Inventory`. Inherits from `AtomVariableInstancer&lt;InventoryVariable, InventoryPair, JuniperJackal.Entity.Inventory, InventoryEvent, InventoryPairEvent, InventoryInventoryFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-hotpink")]
    [AddComponentMenu("Unity Atoms/Variable Instancers/Inventory Variable Instancer")]
    public class InventoryVariableInstancer : AtomVariableInstancer<
        InventoryVariable,
        InventoryPair,
        JuniperJackal.Entity.Inventory,
        InventoryEvent,
        InventoryPairEvent,
        InventoryInventoryFunction>
    { }
}
