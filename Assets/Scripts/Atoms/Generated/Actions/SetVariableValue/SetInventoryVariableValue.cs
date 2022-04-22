using UnityEngine;
using UnityAtoms.BaseAtoms;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Set variable value Action of type `JuniperJackal.Entity.Inventory`. Inherits from `SetVariableValue&lt;JuniperJackal.Entity.Inventory, InventoryPair, InventoryVariable, InventoryConstant, InventoryReference, InventoryEvent, InventoryPairEvent, InventoryVariableInstancer&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-purple")]
    [CreateAssetMenu(menuName = "Unity Atoms/Actions/Set Variable Value/Inventory", fileName = "SetInventoryVariableValue")]
    public sealed class SetInventoryVariableValue : SetVariableValue<
        JuniperJackal.Entity.Inventory,
        InventoryPair,
        InventoryVariable,
        InventoryConstant,
        InventoryReference,
        InventoryEvent,
        InventoryPairEvent,
        InventoryInventoryFunction,
        InventoryVariableInstancer>
    { }
}
