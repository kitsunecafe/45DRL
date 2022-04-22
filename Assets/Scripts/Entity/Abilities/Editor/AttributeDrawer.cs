// using UnityEngine;
// using UnityEditor;
// using Sirenix.OdinInspector.Editor;
// using Sirenix.Utilities.Editor;

// namespace JuniperJackal.Entity
// {
// 	public class AbilityDrawer : OdinValueDrawer<Ability>
// 	{
// 		private InspectorProperty baseValue;

// 		protected override void Initialize()
// 		{
// 			base.Initialize();
// 			baseValue = this.Property.Children["baseValue"];
// 		}

// 		protected override void DrawPropertyLayout(GUIContent label)
// 		{
// 			var rect = EditorGUILayout.GetControlRect();

// 			if (label != null)
// 			{
// 				rect = EditorGUI.PrefixLabel(rect, label);
// 			}

// 			var value = this.ValueEntry.SmartValue;
// 			GUIHelper.PushLabelWidth(20);
// 			baseValue.ValueEntry.WeakSmartValue = SirenixEditorFields.IntField(rect, (int) baseValue.ValueEntry.WeakSmartValue);
// 			GUIHelper.PopLabelWidth();

// 			this.ValueEntry.SmartValue = value;
// 		}
// 	}
// }