using UnityEngine;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Instancer of type `JuniperJackal.Entity.Item`. Inherits from `AtomEventInstancer&lt;JuniperJackal.Entity.Item, ItemEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-sign-blue")]
    [AddComponentMenu("Unity Atoms/Event Instancers/Item Event Instancer")]
    public class ItemEventInstancer : AtomEventInstancer<JuniperJackal.Entity.Item, ItemEvent> { }
}
