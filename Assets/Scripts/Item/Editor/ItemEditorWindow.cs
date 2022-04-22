using UnityEngine;
using UnityEditor;

namespace JuniperJackal.Entity
{
	public class ItemEditorWindow : EditorWindow
	{
		public Item[] Items;

		private Vector2 scrollPosition;
		private Item selectedItem;
		private bool creatingItem = false;
		private Editor editor;

		private ItemFactory factory;

		[MenuItem("Tools/Roguelike/Item Editor")]
		private static void ShowWindow()
		{
			var window = GetWindow<ItemEditorWindow>();
			window.titleContent = new GUIContent("Item Editor");
			window.RefreshItems();
			window.Show();
		}

		public void RefreshItems()
		{
			Items = GetAllInstances<Item>();
		}

		private void OnGUI()
		{
			EditorGUILayout.BeginHorizontal();
			DrawItemList();
			DrawItemDetailsPanel();
			EditorGUILayout.EndHorizontal();
		}

		private void DrawItemList()
		{
			scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, GUILayout.MinWidth(200));

			if (GUILayout.Button("Create New"))
			{
				creatingItem = true;
				factory = new ItemFactory();
			}

			EditorGUILayout.Space();

			for (int i = 0; i < Items.Length; i++)
			{
				if (GUILayout.Button(Items[i].name))
				{
					creatingItem = false;
					selectedItem = Items[i];
				}
			}

			EditorGUILayout.EndScrollView();
		}

		private void DrawItemDetailsPanel()
		{
			if (creatingItem)
			{
				DrawNewItemDetails();
			}
			else if (selectedItem != null)
			{
				DrawExistingItemDetails();
			}
		}

		private void DrawNewItemDetails()
		{
			EditorGUILayout.BeginVertical();

			factory.Name = EditorGUILayout.TextField(factory.Name);
			if (GUILayout.Button("Create"))
			{
				factory.CreateObject();
				RefreshItems();
			}

			EditorGUILayout.EndVertical();
		}

		private void DrawExistingItemDetails()
		{
			EditorGUILayout.BeginVertical();

			DrawToolbar();

			Editor.CreateCachedEditor(selectedItem, null, ref editor);
			editor.OnInspectorGUI();

			EditorGUILayout.EndVertical();
		}

		private void DrawToolbar()
		{
			EditorGUILayout.BeginHorizontal("Toolbar", GUILayout.ExpandWidth(true));
			GUILayout.FlexibleSpace();

			if (GUILayout.Button("Delete", "ToolbarButton", GUILayout.Width(45)))
			{
				DeleteItem(selectedItem);
				RefreshItems();
			}

			EditorGUILayout.EndHorizontal();
		}

		private static void DeleteItem(Item asset)
		{
			var path = AssetDatabase.GetAssetPath(asset);
			AssetDatabase.DeleteAsset(path);
			AssetDatabase.SaveAssets();
		}

		public static T[] GetAllInstances<T>() where T : ScriptableObject
		{
			string[] guids = AssetDatabase.FindAssets("t:" + typeof(T).Name);  //FindAssets uses tags check documentation for more info
			T[] a = new T[guids.Length];
			for (int i = 0; i < guids.Length; i++)         //probably could get optimized 
			{
				string path = AssetDatabase.GUIDToAssetPath(guids[i]);
				a[i] = AssetDatabase.LoadAssetAtPath<T>(path);
			}

			return a;

		}

		private class ItemFactory
		{
			public string Name = "New Item";
			private Item item;

			public void CreateObject()
			{
				item = ScriptableObject.CreateInstance<Item>();
				AssetDatabase.CreateAsset(item, $"Assets/ScriptableObjects/Items/{Name}.asset");
				AssetDatabase.SaveAssets();
				AddNameAttribute();
			}

			private void AddNameAttribute()
			{
				var newAttribute = CreateInstance<NameAttribute>();
				newAttribute.Value = Name;
				newAttribute.hideFlags = HideFlags.HideInHierarchy;
				AssetDatabase.AddObjectToAsset(newAttribute, item);
				AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(newAttribute));
				AssetDatabase.SaveAssets();
				AssetDatabase.Refresh();
				item.Attributes.Add(newAttribute);
			}
		}
	}
}