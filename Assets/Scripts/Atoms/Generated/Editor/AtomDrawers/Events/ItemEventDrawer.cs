#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `JuniperJackal.Entity.Item`. Inherits from `AtomDrawer&lt;ItemEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(ItemEvent))]
    public class ItemEventDrawer : AtomDrawer<ItemEvent> { }
}
#endif
