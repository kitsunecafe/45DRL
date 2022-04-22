using System;
using UnityAtoms.BaseAtoms;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Reference of type `JuniperJackal.Entity.Inventory`. Inherits from `AtomReference&lt;JuniperJackal.Entity.Inventory, InventoryPair, InventoryConstant, InventoryVariable, InventoryEvent, InventoryPairEvent, InventoryInventoryFunction, InventoryVariableInstancer, AtomCollection, AtomList&gt;`.
    /// </summary>
    [Serializable]
    public sealed class InventoryReference : AtomReference<
        JuniperJackal.Entity.Inventory,
        InventoryPair,
        InventoryConstant,
        InventoryVariable,
        InventoryEvent,
        InventoryPairEvent,
        InventoryInventoryFunction,
        InventoryVariableInstancer>, IEquatable<InventoryReference>
    {
        public InventoryReference() : base() { }
        public InventoryReference(JuniperJackal.Entity.Inventory value) : base(value) { }
        public bool Equals(InventoryReference other) { return base.Equals(other); }
        protected override bool ValueEquals(JuniperJackal.Entity.Inventory other)
        {
            throw new NotImplementedException();
        }
    }
}
