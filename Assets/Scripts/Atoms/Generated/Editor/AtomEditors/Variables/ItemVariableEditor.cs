using UnityEditor;
using UnityAtoms.Editor;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Variable Inspector of type `JuniperJackal.Entity.Item`. Inherits from `AtomVariableEditor`
    /// </summary>
    [CustomEditor(typeof(ItemVariable))]
    public sealed class ItemVariableEditor : AtomVariableEditor<JuniperJackal.Entity.Item, ItemPair> { }
}
