using UnityEngine;
using System;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
	/// <summary>
	/// Variable of type `JuniperJackal.Entity.Inventory`. Inherits from `AtomVariable&lt;JuniperJackal.Entity.Inventory, InventoryPair, InventoryEvent, InventoryPairEvent, InventoryInventoryFunction&gt;`.
	/// </summary>
	[EditorIcon("atom-icon-lush")]
	[CreateAssetMenu(menuName = "Unity Atoms/Variables/Inventory", fileName = "InventoryVariable")]
	public sealed class InventoryVariable : AtomVariable<JuniperJackal.Entity.Inventory, InventoryPair, InventoryEvent, InventoryPairEvent, InventoryInventoryFunction>
	{
		protected override bool ValueEquals(JuniperJackal.Entity.Inventory other)
		{
			return Value.Equals(other);
		}
	}
}
