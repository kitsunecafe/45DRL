#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `JuniperJackal.Entity.Inventory`. Inherits from `AtomEventEditor&lt;JuniperJackal.Entity.Inventory, InventoryEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(InventoryEvent))]
    public sealed class InventoryEventEditor : AtomEventEditor<JuniperJackal.Entity.Inventory, InventoryEvent> { }
}
#endif
