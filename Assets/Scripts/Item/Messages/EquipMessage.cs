using JuniperJackal.Entity;

namespace JuniperJackal
{
	public class EquipMessage
	{
		public Equipment EquipmentSource;

		public EquipMessage(Equipment equipmentSource)
		{
			EquipmentSource = equipmentSource;
		}
	}

	public class UnequipMessage
	{
		public Equipment EquipmentSource;

		public UnequipMessage(Equipment equipmentSource)
		{
			EquipmentSource = equipmentSource;
		}
	}
}
