#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `JuniperJackal.Entity.Item`. Inherits from `AtomEventEditor&lt;JuniperJackal.Entity.Item, ItemEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(ItemEvent))]
    public sealed class ItemEventEditor : AtomEventEditor<JuniperJackal.Entity.Item, ItemEvent> { }
}
#endif
