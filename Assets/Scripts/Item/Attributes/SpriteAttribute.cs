using UnityEngine;

namespace JuniperJackal.Entity
{
	public class SpriteAttribute : ValueAttribute<Sprite>
	{
		public override string Label => "Sprite";
		public override string EditorDescription => "The physical representation of the item";
		public override bool VisibleInDescription => false;
	}
}
