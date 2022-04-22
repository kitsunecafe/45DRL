#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Value List property drawer of type `JuniperJackal.Entity.Ability`. Inherits from `AtomDrawer&lt;AbilityValueList&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(AbilityValueList))]
    public class AbilityValueListDrawer : AtomDrawer<AbilityValueList> { }
}
#endif
