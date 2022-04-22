#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Variable property drawer of type `JuniperJackal.Entity.Ability`. Inherits from `AtomDrawer&lt;AbilityVariable&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(AbilityVariable))]
    public class AbilityVariableDrawer : VariableDrawer<AbilityVariable> { }
}
#endif
