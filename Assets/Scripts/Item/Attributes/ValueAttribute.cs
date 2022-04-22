using System;
using System.Collections.Generic;

namespace JuniperJackal.Entity
{
	public class ItemLevelMessage
	{
		public int Value;
	}

	public abstract class ValueAttribute<T> : ItemAttribute
	{
		public override string Label => "Scalar";
		public override string EditorDescription => "A scalar value";
		public T Value = default;

		public override bool Equals(object obj)
		{
			return obj is ValueAttribute<T> attribute &&
						 name == attribute.name &&
						 hideFlags == attribute.hideFlags &&
						 Label == attribute.Label &&
						 EditorDescription == attribute.EditorDescription &&
						 EditorDescription == attribute.Description &&
						 AllowMultiple == attribute.AllowMultiple &&
						 IsCategory == attribute.IsCategory &&
						 Selectable == attribute.Selectable &&
						 EqualityComparer<IItem>.Default.Equals(Source, attribute.Source) &&
						 Label == attribute.Label &&
						 EditorDescription == attribute.EditorDescription &&
						 EqualityComparer<T>.Default.Equals(Value, attribute.Value);
		}

		public override int GetHashCode()
		{
			HashCode hash = new HashCode();
			hash.Add(base.GetHashCode());
			hash.Add(name);
			hash.Add(hideFlags);
			hash.Add(Label);
			hash.Add(EditorDescription);
			hash.Add(Description);
			hash.Add(AllowMultiple);
			hash.Add(IsCategory);
			hash.Add(Selectable);
			hash.Add(Source);
			hash.Add(Label);
			hash.Add(EditorDescription);
			hash.Add(Value);
			return hash.ToHashCode();
		}
	}
}
