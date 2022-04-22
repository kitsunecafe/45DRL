using System;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference of type `JuniperJackal.Entity.Inventory`. Inherits from `AtomEventReference&lt;JuniperJackal.Entity.Inventory, InventoryVariable, InventoryEvent, InventoryVariableInstancer, InventoryEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class InventoryEventReference : AtomEventReference<
        JuniperJackal.Entity.Inventory,
        InventoryVariable,
        InventoryEvent,
        InventoryVariableInstancer,
        InventoryEventInstancer>, IGetEvent 
    { }
}
