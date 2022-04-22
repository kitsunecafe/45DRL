using UnityEngine;

namespace JuniperJackal.Entity
{
	public abstract class TextAttribute : ValueAttribute<string>
	{
		public override string Label => "Text";
		public override string EditorDescription => "A text value";
		public Color Color = Color.white;
	}
}
