using UnityEngine;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Instancer of type `JuniperJackal.Entity.Ability`. Inherits from `AtomEventInstancer&lt;JuniperJackal.Entity.Ability, AbilityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-sign-blue")]
    [AddComponentMenu("Unity Atoms/Event Instancers/Ability Event Instancer")]
    public class AbilityEventInstancer : AtomEventInstancer<JuniperJackal.Entity.Ability, AbilityEvent> { }
}
