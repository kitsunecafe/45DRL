using System;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference of type `ItemPair`. Inherits from `AtomEventReference&lt;ItemPair, ItemVariable, ItemPairEvent, ItemVariableInstancer, ItemPairEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class ItemPairEventReference : AtomEventReference<
        ItemPair,
        ItemVariable,
        ItemPairEvent,
        ItemVariableInstancer,
        ItemPairEventInstancer>, IGetEvent 
    { }
}
