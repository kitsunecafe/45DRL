using System;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference of type `AbilityPair`. Inherits from `AtomEventReference&lt;AbilityPair, AbilityVariable, AbilityPairEvent, AbilityVariableInstancer, AbilityPairEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class AbilityPairEventReference : AtomEventReference<
        AbilityPair,
        AbilityVariable,
        AbilityPairEvent,
        AbilityVariableInstancer,
        AbilityPairEventInstancer>, IGetEvent 
    { }
}
