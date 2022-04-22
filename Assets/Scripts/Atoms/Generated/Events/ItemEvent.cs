using UnityEngine;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event of type `JuniperJackal.Entity.Item`. Inherits from `AtomEvent&lt;JuniperJackal.Entity.Item&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/Item", fileName = "ItemEvent")]
    public sealed class ItemEvent : AtomEvent<JuniperJackal.Entity.Item>
    {
    }
}
