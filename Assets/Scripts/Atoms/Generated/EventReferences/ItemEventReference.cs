using System;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference of type `JuniperJackal.Entity.Item`. Inherits from `AtomEventReference&lt;JuniperJackal.Entity.Item, ItemVariable, ItemEvent, ItemVariableInstancer, ItemEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class ItemEventReference : AtomEventReference<
        JuniperJackal.Entity.Item,
        ItemVariable,
        ItemEvent,
        ItemVariableInstancer,
        ItemEventInstancer>, IGetEvent 
    { }
}
