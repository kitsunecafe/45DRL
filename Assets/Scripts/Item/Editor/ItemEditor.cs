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
	[CustomEditor(typeof(Item))]
	public class ItemEditor : Editor
	{

		private const string AttributesPropertyName = "Attributes";
		// Holds ItemAttribute types for popup:
		private Type[] m_attributeTypes = new Type[0];
		private string[] m_attributeTypeNames = new string[0];
		private int m_attributeTypeIndex = -1;
		private Assembly assembly;
		private ReorderableList list;
		private SerializedProperty attributesProperty;

		private void OnEnable()
		{
			// Fill the popup list:
			Type[] types = Assembly.GetAssembly(typeof(ItemAttribute)).GetTypes();
			m_attributeTypes = types.Where(type => type.IsSubclassOf(typeof(ItemAttribute)))
				.Where(type => !type.IsAbstract)
				.ToArray();

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
			return EditorGUI.GetPropertyHeight(
				attributesProperty.GetArrayElementAtIndex(index)
			);
		}

		private void DrawHeader(Rect rect)
		{
			EditorGUI.LabelField(rect, AttributesPropertyName);
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

			var item = target as Item;
			list.DoLayoutList();
			EditorGUILayout.BeginHorizontal();
			m_attributeTypeIndex = EditorGUILayout.Popup(m_attributeTypeIndex, m_attributeTypeNames);
			if (
				GUILayout.Button("Add Attribute")
				&& AssetDatabase.Contains(item)
				&& CanAddAttribute(item)
			)
			{
				// A little tricky because we need to record it in the asset database, too:
				var newAttribute = CreateInstance(m_attributeTypeNames[m_attributeTypeIndex]) as ItemAttribute;
				newAttribute.hideFlags = HideFlags.HideInHierarchy;
				AssetDatabase.AddObjectToAsset(newAttribute, item);
				AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(newAttribute));
				AssetDatabase.SaveAssets();
				AssetDatabase.Refresh();
				item.Attributes.Add(newAttribute);
			}
			EditorGUILayout.EndHorizontal();

			if (item != null && GUI.changed) EditorUtility.SetDirty(item);

			if (EditorGUI.EndChangeCheck())
			{
				serializedObject.ApplyModifiedProperties();
			}
		}

		private bool CanAddAttribute(Item item)
		{
			var type = m_attributeTypes[m_attributeTypeIndex];
			if (item.HasAttribute(type))
			{
				var attribute = item.GetAttributes(type).First();
				if (!attribute.AllowMultiple)
				{
					Debug.LogWarning($"{m_attributeTypeNames[m_attributeTypeIndex]} already added.");
					m_attributeTypeIndex = -1;
					return false;
				}
			}

			return true;
		}
	}
}
