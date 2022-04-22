using UnityEditor;
using UnityAtoms.Editor;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Variable Inspector of type `JuniperJackal.Entity.Ability`. Inherits from `AtomVariableEditor`
    /// </summary>
    [CustomEditor(typeof(AbilityVariable))]
    public sealed class AbilityVariableEditor : AtomVariableEditor<JuniperJackal.Entity.Ability, AbilityPair> { }
}
