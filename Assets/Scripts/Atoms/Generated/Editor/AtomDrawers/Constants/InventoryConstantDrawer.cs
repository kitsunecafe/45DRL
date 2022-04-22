#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Constant property drawer of type `JuniperJackal.Entity.Inventory`. Inherits from `AtomDrawer&lt;InventoryConstant&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(InventoryConstant))]
    public class InventoryConstantDrawer : VariableDrawer<InventoryConstant> { }
}
#endif
