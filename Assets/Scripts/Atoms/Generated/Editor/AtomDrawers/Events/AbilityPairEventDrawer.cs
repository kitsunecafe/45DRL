#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `AbilityPair`. Inherits from `AtomDrawer&lt;AbilityPairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(AbilityPairEvent))]
    public class AbilityPairEventDrawer : AtomDrawer<AbilityPairEvent> { }
}
#endif
