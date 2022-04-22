using System;
using UnityEngine.Events;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// None generic Unity Event of type `JuniperJackal.Entity.Item`. Inherits from `UnityEvent&lt;JuniperJackal.Entity.Item&gt;`.
    /// </summary>
    [Serializable]
    public sealed class ItemUnityEvent : UnityEvent<JuniperJackal.Entity.Item> { }
}
