// using UnityEngine;
// using UnityEditor;
// using System;
// using System.Reflection;
// using System.Linq;
// using JuniperJackal.Extensions;
// using UnityEditorInternal;

// /*
// 	Information for ReorderableList from
// 	https://sites.google.com/site/tuxnots/gamming/unity3d/unitymakeyourlistsfunctionalwithreorderablelist
// */
// namespace JuniperJackal.Entity
// {
// 	[CustomEditor(typeof(Item))]
// 	public class ItemEditor : Editor
// 	{

// 		// Holds ItemAttribute types for popup:
// 		private Type[] m_attributeTypes = new Type[0];
// 		private string[] m_attributeTypeNames = new string[0];
// 		private int m_attributeTypeIndex = -1;
// 		private Assembly assembly;
// 		private ReorderableList list;

// 		private void OnEnable()
// 		{
// 			// Fill the popup list:
// 			Type[] types = Assembly.GetAssembly(typeof(ItemAttribute)).GetTypes();
// 			m_attributeTypes = types.Where(type => type.IsSubclassOf(typeof(ItemAttribute)))
// 				.Where(type => !type.IsAbstract)
// 				.ToArray();

// 			m_attributeTypeNames = m_attributeTypes.Select(type => type.FullName).ToArray();
// 			// m_attributeTypes = (from Type type in types where type.IsSubclassOf(typeof(ItemAttribute)) select type.FullName).ToArray();
// 			list = new ReorderableList(
// 				serializedObject,
// 				serializedObject.FindProperty("Attributes"),
// 				true,
// 				true,
// 				true,
// 				true
// 			);

// 			list.drawHeaderCallback = DrawHeader;
// 			list.drawElementCallback = DrawListItems;
// 			list.displayAdd = false;
// 		}

// 		private bool IsSelectable(Type type)
// 		{
// 			var instance = ScriptableObject.CreateInstance(type) as ItemAttribute;

// 			var selectable = instance.Selectable;
// 			ScriptableObject.DestroyImmediate(instance);

// 			return selectable;
// 		}

// 		private void DrawHeader(Rect rect)
// 		{
// 			EditorGUI.LabelField(rect, "Attributes");
// 		}

// 		private void DrawListItems(Rect rect, int index, bool isActive, bool isFocused)
// 		{
// 			var item = target as Item;
// 			EditorGUILayout.BeginHorizontal();
// 			// if (item.Attributes[index] != null) item.Attributes[index].DoLayout(rect);
// 			EditorGUILayout.EndHorizontal();
// 		}

// 		public override void OnInspectorGUI()
// 		{
// 			var item = target as Item;
// 			serializedObject.Update();
// 			list.DoLayoutList();
// 			EditorGUILayout.BeginHorizontal();
// 			m_attributeTypeIndex = EditorGUILayout.Popup(m_attributeTypeIndex, m_attributeTypeNames);
// 			if (
// 				GUILayout.Button("Add Attribute")
// 				&& AssetDatabase.Contains(item)
// 				&& CanAddAttribute(item)
// 			)
// 			{
// 				// A little tricky because we need to record it in the asset database, too:
// 				var newAttribute = CreateInstance(m_attributeTypeNames[m_attributeTypeIndex]) as ItemAttribute;
// 				newAttribute.hideFlags = HideFlags.HideInHierarchy;
// 				AssetDatabase.AddObjectToAsset(newAttribute, item);
// 				AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(newAttribute));
// 				AssetDatabase.SaveAssets();
// 				AssetDatabase.Refresh();
// 				item.Attributes.Add(newAttribute);
// 			}
// 			EditorGUILayout.EndHorizontal();

// 			if (item != null && GUI.changed) EditorUtility.SetDirty(item);
// 			serializedObject.ApplyModifiedProperties();
// 		}

// 		// public override void OnInspectorGUI()
// 		// {
// 		// 	var item = target as Item;

// 		// 	// Draw attributes with a delete button below each one:
// 		// 	int indexToDelete = -1;
// 		// 	var options = new GUILayoutOption[] {
// 		// 		GUILayout.ExpandWidth(false)
// 		// 	};

// 		// 	for (int i = 0; i < item.Attributes.Count; i++)
// 		// 	{
// 		// 		EditorGUILayout.BeginHorizontal(EditorStyles.helpBox);
// 		// 		if (item.Attributes[i] != null) item.Attributes[i].DoLayout();
// 		// 		if (GUILayout.Button("-", options)) indexToDelete = i;
// 		// 		EditorGUILayout.EndHorizontal();
// 		// 	}
// 		// 	if (indexToDelete > -1) item.Attributes.RemoveAt(indexToDelete);

// 		// 	// Draw a popup and button to add a new attribute:
// 		// 	EditorGUILayout.BeginHorizontal();
// 		// 	m_attributeTypeIndex = EditorGUILayout.Popup(m_attributeTypeIndex, m_attributeTypeNames);
// 		// 	if (
// 		// 		GUILayout.Button("Add")
// 		// 		&& AssetDatabase.Contains(item)
// 		// 		&& CanAddAttribute(item)
// 		// 	)
// 		// 	{
// 		// 		// A little tricky because we need to record it in the asset database, too:
// 		// 		var newAttribute = CreateInstance(m_attributeTypeNames[m_attributeTypeIndex]) as ItemAttribute;
// 		// 		newAttribute.hideFlags = HideFlags.HideInHierarchy;
// 		// 		AssetDatabase.AddObjectToAsset(newAttribute, item);
// 		// 		AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(newAttribute));
// 		// 		AssetDatabase.SaveAssets();
// 		// 		AssetDatabase.Refresh();
// 		// 		item.Attributes.Add(newAttribute);
// 		// 	}
// 		// 	EditorGUILayout.EndHorizontal();

// 		// 	if (item != null && GUI.changed) EditorUtility.SetDirty(item);
// 		// }

// 		private bool CanAddAttribute(Item item)
// 		{
// 			var type = m_attributeTypes[m_attributeTypeIndex];
// 			if (item.HasAttribute(type))
// 			{
// 				var attribute = item.GetAttributes(type).First();
// 				if (!attribute.AllowMultiple)
// 				{
// 					Debug.LogWarning($"{m_attributeTypeNames[m_attributeTypeIndex]} already added.");
// 					m_attributeTypeIndex = -1;
// 					return false;
// 				}
// 			}

// 			return true;
// 		}
// 	}
// }
