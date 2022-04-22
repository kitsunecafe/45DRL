using UnityEngine;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event of type `ItemPair`. Inherits from `AtomEvent&lt;ItemPair&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/ItemPair", fileName = "ItemPairEvent")]
    public sealed class ItemPairEvent : AtomEvent<ItemPair>
    {
    }
}
