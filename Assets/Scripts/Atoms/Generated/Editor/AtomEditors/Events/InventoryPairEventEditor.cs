#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `InventoryPair`. Inherits from `AtomEventEditor&lt;InventoryPair, InventoryPairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(InventoryPairEvent))]
    public sealed class InventoryPairEventEditor : AtomEventEditor<InventoryPair, InventoryPairEvent> { }
}
#endif
