using UnityEngine;
using UnityAtoms.BaseAtoms;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Variable Instancer of type `JuniperJackal.Entity.Item`. Inherits from `AtomVariableInstancer&lt;ItemVariable, ItemPair, JuniperJackal.Entity.Item, ItemEvent, ItemPairEvent, ItemItemFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-hotpink")]
    [AddComponentMenu("Unity Atoms/Variable Instancers/Item Variable Instancer")]
    public class ItemVariableInstancer : AtomVariableInstancer<
        ItemVariable,
        ItemPair,
        JuniperJackal.Entity.Item,
        ItemEvent,
        ItemPairEvent,
        ItemItemFunction>
    { }
}
