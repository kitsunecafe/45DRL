using System;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference of type `InventoryPair`. Inherits from `AtomEventReference&lt;InventoryPair, InventoryVariable, InventoryPairEvent, InventoryVariableInstancer, InventoryPairEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class InventoryPairEventReference : AtomEventReference<
        InventoryPair,
        InventoryVariable,
        InventoryPairEvent,
        InventoryVariableInstancer,
        InventoryPairEventInstancer>, IGetEvent 
    { }
}
