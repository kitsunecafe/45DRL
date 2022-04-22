#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `InventoryPair`. Inherits from `AtomDrawer&lt;InventoryPairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(InventoryPairEvent))]
    public class InventoryPairEventDrawer : AtomDrawer<InventoryPairEvent> { }
}
#endif
