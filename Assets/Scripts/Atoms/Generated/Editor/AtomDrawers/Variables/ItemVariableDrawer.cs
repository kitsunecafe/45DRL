#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Variable property drawer of type `JuniperJackal.Entity.Item`. Inherits from `AtomDrawer&lt;ItemVariable&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(ItemVariable))]
    public class ItemVariableDrawer : VariableDrawer<ItemVariable> { }
}
#endif
