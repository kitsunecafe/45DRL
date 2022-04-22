using UnityEngine;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event of type `InventoryPair`. Inherits from `AtomEvent&lt;InventoryPair&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/InventoryPair", fileName = "InventoryPairEvent")]
    public sealed class InventoryPairEvent : AtomEvent<InventoryPair>
    {
    }
}
