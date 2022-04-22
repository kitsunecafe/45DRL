using UnityEngine;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Value List of type `JuniperJackal.Entity.Item`. Inherits from `AtomValueList&lt;JuniperJackal.Entity.Item, ItemEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-piglet")]
    [CreateAssetMenu(menuName = "Unity Atoms/Value Lists/Item", fileName = "ItemValueList")]
    public sealed class ItemValueList : AtomValueList<JuniperJackal.Entity.Item, ItemEvent> { }
}
