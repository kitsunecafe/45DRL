#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `JuniperJackal.Entity.Ability`. Inherits from `AtomEventEditor&lt;JuniperJackal.Entity.Ability, AbilityEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(AbilityEvent))]
    public sealed class AbilityEventEditor : AtomEventEditor<JuniperJackal.Entity.Ability, AbilityEvent> { }
}
#endif
