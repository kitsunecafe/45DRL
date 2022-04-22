using UnityEngine;
using UnityAtoms.BaseAtoms;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Adds Variable Instancer's Variable of type JuniperJackal.Entity.Item to a Collection or List on OnEnable and removes it on OnDestroy. 
    /// </summary>
    [AddComponentMenu("Unity Atoms/Sync Variable Instancer to Collection/Sync Item Variable Instancer to Collection")]
    [EditorIcon("atom-icon-delicate")]
    public class SyncItemVariableInstancerToCollection : SyncVariableInstancerToCollection<JuniperJackal.Entity.Item, ItemVariable, ItemVariableInstancer> { }
}
