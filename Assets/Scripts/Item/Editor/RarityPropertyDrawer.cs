using UnityEngine;
using UnityEditor;
using System.Reflection;
using JuniperJackal.Entity;
using System.Linq;

namespace JuniperJackal
{
	[CustomPropertyDrawer(typeof(Rarity))]
	public class RarityPropertyDrawer : PropertyDrawer
	{
		private const string ValuePropertyName = "value";
		private const string DisplayNamePropertyName = "displayName";
		private const string MinimumModifiersPropertyName = nameof(Rarity.MinimumModifiers);
		private const string MaximumModifiersPropertyName = nameof(Rarity.MaximumModifiers);
		private const string ColorPropertyName = nameof(Rarity.Color);

		private string[] rarityNames = new string[0];
		private bool initialized = false;

		private void TryInitialize()
		{
			if (!initialized)
			{
				rarityNames = typeof(Rarity)
					.GetFields(BindingFlags.Public | BindingFlags.Static)
					.Where(f => f.FieldType == typeof(Rarity))
					.Select(f => f.GetValue(null) as Rarity)
					.OrderBy(f => f.Value)
					.Select(r => r.DisplayName)
					.ToArray();
			}
		}

		private void DebugProperty(SerializedProperty property)
		{
			SerializedProperty it = property.Copy();
			Debug.Log($"Debugging {it.name}");
			while (it.Next(true))
			{
				Debug.Log(it.name);
			}
		}

		private bool PropertyInitialized(SerializedProperty property)
		{
			return property.FindPropertyRelative(DisplayNamePropertyName).stringValue != "";
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			TryInitialize();

			var value = property.FindPropertyRelative(ValuePropertyName);
			var displayName = property.FindPropertyRelative(DisplayNamePropertyName);
			var min = property.FindPropertyRelative(MinimumModifiersPropertyName);
			var max = property.FindPropertyRelative(MaximumModifiersPropertyName);
			var color = property.FindPropertyRelative(ColorPropertyName);

			EditorGUI.BeginProperty(position, label, property);
			{
				EditorGUI.BeginChangeCheck();
				var index = EditorGUI.Popup(position, value.intValue, rarityNames);

				if (EditorGUI.EndChangeCheck() || !PropertyInitialized(property))
				{
					var rarity = Enumeration.FromValue<Rarity>(index);
					value.intValue = rarity.Value;
					displayName.stringValue = rarity.DisplayName;
					min.intValue = rarity.MinimumModifiers;
					max.intValue = rarity.MaximumModifiers;
					color.colorValue = rarity.Color;
				}
			}
			EditorGUI.EndProperty();
		}
	}
}