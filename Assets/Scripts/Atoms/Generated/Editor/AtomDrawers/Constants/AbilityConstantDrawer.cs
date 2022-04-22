#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Constant property drawer of type `JuniperJackal.Entity.Ability`. Inherits from `AtomDrawer&lt;AbilityConstant&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(AbilityConstant))]
    public class AbilityConstantDrawer : VariableDrawer<AbilityConstant> { }
}
#endif
