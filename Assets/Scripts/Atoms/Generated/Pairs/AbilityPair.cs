using System;
using UnityEngine;
using JuniperJackal.Entity;
namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// IPair of type `&lt;JuniperJackal.Entity.Ability&gt;`. Inherits from `IPair&lt;JuniperJackal.Entity.Ability&gt;`.
    /// </summary>
    [Serializable]
    public struct AbilityPair : IPair<JuniperJackal.Entity.Ability>
    {
        public JuniperJackal.Entity.Ability Item1 { get => _item1; set => _item1 = value; }
        public JuniperJackal.Entity.Ability Item2 { get => _item2; set => _item2 = value; }

        [SerializeField]
        private JuniperJackal.Entity.Ability _item1;
        [SerializeField]
        private JuniperJackal.Entity.Ability _item2;

        public void Deconstruct(out JuniperJackal.Entity.Ability item1, out JuniperJackal.Entity.Ability item2) { item1 = Item1; item2 = Item2; }
    }
}