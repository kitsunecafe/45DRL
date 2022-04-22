using UnityEditor;
using UnityAtoms.Editor;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Variable Inspector of type `JuniperJackal.Entity.Inventory`. Inherits from `AtomVariableEditor`
    /// </summary>
    [CustomEditor(typeof(InventoryVariable))]
    public sealed class InventoryVariableEditor : AtomVariableEditor<JuniperJackal.Entity.Inventory, InventoryPair> { }
}
