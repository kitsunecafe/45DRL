using UnityEngine;
using UnityEditor;
using System;
using System.Reflection;
using System.Linq;
using JuniperJackal.Extensions;
using UnityEditorInternal;

/*
	Information for ReorderableList from
	https://sites.google.com/site/tuxnots/gamming/unity3d/unitymakeyourlistsfunctionalwithreorderablelist
*/
namespace JuniperJackal.Entity
{
	[CustomEditor(typeof(Loot))]
	public class LootEditor : Editor
	{

		private const string AttributesPropertyName = "attributes";
		// Holds ItemAttribute types for popup:
		private Type[] m_attributeTypes = new Type[0];
		private string[] m_attributeTypeNames = new string[0];
		private int m_attributeTypeIndex = -1;
		private Assembly assembly;
		private ReorderableList list;
		private SerializedProperty attributesProperty;

		private void OnEnable()
		{
			m_attributeTypes = ItemAttribute.AllAttributeTypes;

			m_attributeTypeNames = m_attributeTypes.Select(type => type.FullName).ToArray();
			attributesProperty = serializedObject.FindProperty(AttributesPropertyName);

			list = new ReorderableList(
				serializedObject,
				attributesProperty,
				true,
				true,
				true,
				true
			);

			list.drawHeaderCallback = DrawHeader;
			list.drawElementCallback = DrawListItems;
			list.elementHeightCallback = GetElementHeight;
			list.displayAdd = false;
		}

		private bool IsSelectable(Type type)
		{
			var instance = ScriptableObject.CreateInstance(type) as ItemAttribute;

			var selectable = instance.Selectable;
			ScriptableObject.DestroyImmediate(instance);

			return selectable;
		}

		private float GetElementHeight(int index)
		{
			return index < 0 || attributesProperty.arraySize <= index ? 0 : EditorGUI.GetPropertyHeight(
				attributesProperty.GetArrayElementAtIndex(index)
			);
		}

		private void DrawHeader(Rect rect)
		{
			EditorGUI.LabelField(rect, "Attributes");
		}

		private void DrawListItems(Rect rect, int index, bool isActive, bool isFocused)
		{
			var item = target as Item;
			EditorGUI.PropertyField(rect, attributesProperty.GetArrayElementAtIndex(index));
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();
			EditorGUI.BeginChangeCheck();
			DrawPropertiesExcluding(serializedObject, AttributesPropertyName);

			var loot = target as Loot;
			list.DoLayoutList();
			EditorGUILayout.BeginHorizontal();
			m_attributeTypeIndex = EditorGUILayout.Popup(m_attributeTypeIndex, m_attributeTypeNames);
			if (
				GUILayout.Button("Add Attribute")
				&& AssetDatabase.Contains(loot)
			)
			{
				// A little tricky because we need to record it in the asset database, too:
				var newAttribute = CreateInstance(m_attributeTypeNames[m_attributeTypeIndex]) as ItemAttribute;
				newAttribute.hideFlags = HideFlags.HideInHierarchy;
				AssetDatabase.AddObjectToAsset(newAttribute, loot);
				AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(newAttribute));
				AssetDatabase.SaveAssets();
				AssetDatabase.Refresh();
				loot.Attributes.Add(newAttribute);
			}
			EditorGUILayout.EndHorizontal();

			if (loot != null && GUI.changed) EditorUtility.SetDirty(loot);

			if (EditorGUI.EndChangeCheck())
			{
				serializedObject.ApplyModifiedProperties();
			}
		}
	}
}
