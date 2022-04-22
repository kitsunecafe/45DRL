#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Constant property drawer of type `JuniperJackal.Entity.Item`. Inherits from `AtomDrawer&lt;ItemConstant&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(ItemConstant))]
    public class ItemConstantDrawer : VariableDrawer<ItemConstant> { }
}
#endif
