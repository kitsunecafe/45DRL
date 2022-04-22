using System;
using UnityEngine;
using JuniperJackal.Entity;
namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// IPair of type `&lt;JuniperJackal.Entity.Item&gt;`. Inherits from `IPair&lt;JuniperJackal.Entity.Item&gt;`.
    /// </summary>
    [Serializable]
    public struct ItemPair : IPair<JuniperJackal.Entity.Item>
    {
        public JuniperJackal.Entity.Item Item1 { get => _item1; set => _item1 = value; }
        public JuniperJackal.Entity.Item Item2 { get => _item2; set => _item2 = value; }

        [SerializeField]
        private JuniperJackal.Entity.Item _item1;
        [SerializeField]
        private JuniperJackal.Entity.Item _item2;

        public void Deconstruct(out JuniperJackal.Entity.Item item1, out JuniperJackal.Entity.Item item2) { item1 = Item1; item2 = Item2; }
    }
}