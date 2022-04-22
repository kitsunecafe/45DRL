using System;
using UnityEngine.Events;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// None generic Unity Event of type `ItemPair`. Inherits from `UnityEvent&lt;ItemPair&gt;`.
    /// </summary>
    [Serializable]
    public sealed class ItemPairUnityEvent : UnityEvent<ItemPair> { }
}
