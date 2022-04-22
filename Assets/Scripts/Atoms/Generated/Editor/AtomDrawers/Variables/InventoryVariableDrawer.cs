#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Variable property drawer of type `JuniperJackal.Entity.Inventory`. Inherits from `AtomDrawer&lt;InventoryVariable&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(InventoryVariable))]
    public class InventoryVariableDrawer : VariableDrawer<InventoryVariable> { }
}
#endif
