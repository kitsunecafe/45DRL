using UnityEngine;
using System;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
	/// <summary>
	/// Variable of type `JuniperJackal.Entity.Item`. Inherits from `AtomVariable&lt;JuniperJackal.Entity.Item, ItemPair, ItemEvent, ItemPairEvent, ItemItemFunction&gt;`.
	/// </summary>
	[EditorIcon("atom-icon-lush")]
	[CreateAssetMenu(menuName = "Unity Atoms/Variables/Item", fileName = "ItemVariable")]
	public sealed class ItemVariable : AtomVariable<JuniperJackal.Entity.Item, ItemPair, ItemEvent, ItemPairEvent, ItemItemFunction>
	{
		protected override bool ValueEquals(JuniperJackal.Entity.Item other)
		{
            return this.Value == other;
		}
	}
}
