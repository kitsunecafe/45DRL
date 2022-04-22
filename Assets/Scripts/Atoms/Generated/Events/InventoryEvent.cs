using UnityEngine;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event of type `JuniperJackal.Entity.Inventory`. Inherits from `AtomEvent&lt;JuniperJackal.Entity.Inventory&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/Inventory", fileName = "InventoryEvent")]
    public sealed class InventoryEvent : AtomEvent<JuniperJackal.Entity.Inventory>
    {
    }
}
