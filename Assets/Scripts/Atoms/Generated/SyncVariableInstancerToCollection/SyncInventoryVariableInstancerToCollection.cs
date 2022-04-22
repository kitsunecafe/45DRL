using UnityEngine;
using UnityAtoms.BaseAtoms;
using JuniperJackal.Entity;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Adds Variable Instancer's Variable of type JuniperJackal.Entity.Inventory to a Collection or List on OnEnable and removes it on OnDestroy. 
    /// </summary>
    [AddComponentMenu("Unity Atoms/Sync Variable Instancer to Collection/Sync Inventory Variable Instancer to Collection")]
    [EditorIcon("atom-icon-delicate")]
    public class SyncInventoryVariableInstancerToCollection : SyncVariableInstancerToCollection<JuniperJackal.Entity.Inventory, InventoryVariable, InventoryVariableInstancer> { }
}
