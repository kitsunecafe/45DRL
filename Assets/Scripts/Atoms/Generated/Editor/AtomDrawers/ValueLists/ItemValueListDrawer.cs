#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Value List property drawer of type `JuniperJackal.Entity.Item`. Inherits from `AtomDrawer&lt;ItemValueList&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(ItemValueList))]
    public class ItemValueListDrawer : AtomDrawer<ItemValueList> { }
}
#endif
