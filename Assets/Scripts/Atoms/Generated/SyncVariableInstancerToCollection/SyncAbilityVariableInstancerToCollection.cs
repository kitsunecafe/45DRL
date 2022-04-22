using UnityEngine;
using UnityAtoms.BaseAtoms;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Adds Variable Instancer's Variable of type JuniperJackal.Entity.Ability to a Collection or List on OnEnable and removes it on OnDestroy. 
    /// </summary>
    [AddComponentMenu("Unity Atoms/Sync Variable Instancer to Collection/Sync Ability Variable Instancer to Collection")]
    [EditorIcon("atom-icon-delicate")]
    public class SyncAbilityVariableInstancerToCollection : SyncVariableInstancerToCollection<JuniperJackal.Entity.Ability, AbilityVariable, AbilityVariableInstancer> { }
}
