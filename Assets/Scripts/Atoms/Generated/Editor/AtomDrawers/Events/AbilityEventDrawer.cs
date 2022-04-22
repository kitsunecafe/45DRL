#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `JuniperJackal.Entity.Ability`. Inherits from `AtomDrawer&lt;AbilityEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(AbilityEvent))]
    public class AbilityEventDrawer : AtomDrawer<AbilityEvent> { }
}
#endif
