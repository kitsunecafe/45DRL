#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `ItemPair`. Inherits from `AtomEventEditor&lt;ItemPair, ItemPairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(ItemPairEvent))]
    public sealed class ItemPairEventEditor : AtomEventEditor<ItemPair, ItemPairEvent> { }
}
#endif
