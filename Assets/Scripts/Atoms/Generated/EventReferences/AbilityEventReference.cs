using System;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference of type `JuniperJackal.Entity.Ability`. Inherits from `AtomEventReference&lt;JuniperJackal.Entity.Ability, AbilityVariable, AbilityEvent, AbilityVariableInstancer, AbilityEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class AbilityEventReference : AtomEventReference<
        JuniperJackal.Entity.Ability,
        AbilityVariable,
        AbilityEvent,
        AbilityVariableInstancer,
        AbilityEventInstancer>, IGetEvent 
    { }
}
