using System;
using UnityEngine;
using JuniperJackal.Entity;
namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// IPair of type `&lt;JuniperJackal.Entity.Inventory&gt;`. Inherits from `IPair&lt;JuniperJackal.Entity.Inventory&gt;`.
    /// </summary>
    [Serializable]
    public struct InventoryPair : IPair<JuniperJackal.Entity.Inventory>
    {
        public JuniperJackal.Entity.Inventory Item1 { get => _item1; set => _item1 = value; }
        public JuniperJackal.Entity.Inventory Item2 { get => _item2; set => _item2 = value; }

        [SerializeField]
        private JuniperJackal.Entity.Inventory _item1;
        [SerializeField]
        private JuniperJackal.Entity.Inventory _item2;

        public void Deconstruct(out JuniperJackal.Entity.Inventory item1, out JuniperJackal.Entity.Inventory item2) { item1 = Item1; item2 = Item2; }
    }
}