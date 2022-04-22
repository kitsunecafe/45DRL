using UnityEngine;
using UnityAtoms.BaseAtoms;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Set variable value Action of type `JuniperJackal.Entity.Item`. Inherits from `SetVariableValue&lt;JuniperJackal.Entity.Item, ItemPair, ItemVariable, ItemConstant, ItemReference, ItemEvent, ItemPairEvent, ItemVariableInstancer&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-purple")]
    [CreateAssetMenu(menuName = "Unity Atoms/Actions/Set Variable Value/Item", fileName = "SetItemVariableValue")]
    public sealed class SetItemVariableValue : SetVariableValue<
        JuniperJackal.Entity.Item,
        ItemPair,
        ItemVariable,
        ItemConstant,
        ItemReference,
        ItemEvent,
        ItemPairEvent,
        ItemItemFunction,
        ItemVariableInstancer>
    { }
}
