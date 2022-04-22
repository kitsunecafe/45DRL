#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `AbilityPair`. Inherits from `AtomEventEditor&lt;AbilityPair, AbilityPairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(AbilityPairEvent))]
    public sealed class AbilityPairEventEditor : AtomEventEditor<AbilityPair, AbilityPairEvent> { }
}
#endif
