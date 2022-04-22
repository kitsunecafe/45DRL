using System.Collections.Generic;

namespace JuniperJackal.Entity
{
	public class VersatileProperty : ItemProperty
	{
		public override string Label => "Versatile";
		public override string EditorDescription => "This item can be wielded with one or two hands.";
		public static readonly Dice Value = new Dice(1, 2);
	}
}
