using System;
using UnityAtoms.BaseAtoms;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Reference of type `JuniperJackal.Entity.Item`. Inherits from `AtomReference&lt;JuniperJackal.Entity.Item, ItemPair, ItemConstant, ItemVariable, ItemEvent, ItemPairEvent, ItemItemFunction, ItemVariableInstancer, AtomCollection, AtomList&gt;`.
    /// </summary>
    [Serializable]
    public sealed class ItemReference : AtomReference<
        JuniperJackal.Entity.Item,
        ItemPair,
        ItemConstant,
        ItemVariable,
        ItemEvent,
        ItemPairEvent,
        ItemItemFunction,
        ItemVariableInstancer>, IEquatable<ItemReference>
    {
        public ItemReference() : base() { }
        public ItemReference(JuniperJackal.Entity.Item value) : base(value) { }
        public bool Equals(ItemReference other) { return base.Equals(other); }
        protected override bool ValueEquals(JuniperJackal.Entity.Item other)
        {
            throw new NotImplementedException();
        }
    }
}
