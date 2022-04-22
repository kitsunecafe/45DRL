using UnityEngine;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Instancer of type `AbilityPair`. Inherits from `AtomEventInstancer&lt;AbilityPair, AbilityPairEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-sign-blue")]
    [AddComponentMenu("Unity Atoms/Event Instancers/AbilityPair Event Instancer")]
    public class AbilityPairEventInstancer : AtomEventInstancer<AbilityPair, AbilityPairEvent> { }
}
