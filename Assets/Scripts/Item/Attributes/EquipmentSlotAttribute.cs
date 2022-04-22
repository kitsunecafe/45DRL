namespace JuniperJackal.Entity
{
	public class EquipmentSlotAttribute : ValueAttribute<EquipmentSlot>
	{
		public override string Label => "Equipment Slot";
		public override string EditorDescription => "The slot this item can be equipped";
		public override string Description => $"Equippable to {Value}";
	}
}

