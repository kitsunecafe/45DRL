// using Sirenix.OdinInspector;
// using Sirenix.OdinInspector.Editor;
// using Sirenix.Utilities.Editor;
// using UnityEditor;
// using UnityEngine;

// namespace JuniperJackal.Entity
// {
// 	public class ItemEditorWindow : OdinMenuEditorWindow
// 	{
// 		private CreateNewItem createNewItem;

// 		[MenuItem("Tools/Items")]
// 		private static void OpenWindow()
// 		{
// 			GetWindow<ItemEditorWindow>().Show();
// 		}

// 		// protected override void OnDestroy()
// 		// {
// 		// 	base.OnDestroy();

// 		// 	if (createNewItem != null)
// 		// 	{
// 		// 		DestroyImmediate(createNewItem);
// 		// 	}
// 		// }

// 		protected override void OnBeginDrawEditors()
// 		{
// 			base.OnBeginDrawEditors();

// 			var selected = this.MenuTree.Selection;

// 			SirenixEditorGUI.BeginHorizontalToolbar();
// 			{
// 				GUILayout.FlexibleSpace();

// 				if (SirenixEditorGUI.ToolbarButton("Delete"))
// 				{
// 					Item asset = selected.SelectedValue as Item;
// 					var path = AssetDatabase.GetAssetPath(asset);
// 					AssetDatabase.DeleteAsset(path);
// 					AssetDatabase.SaveAssets();
// 				}
// 			}

// 			SirenixEditorGUI.EndHorizontalToolbar();
// 		}

// 		protected override OdinMenuTree BuildMenuTree()
// 		{
// 			var tree = new OdinMenuTree();
// 			createNewItem = new CreateNewItem();
// 			tree.Add("New Item", createNewItem);
// 			tree.AddAllAssetsAtPath("Items", "Assets/ScriptableObjects/Items", typeof(Item));
// 			return tree;
// 		}

// 		public class CreateNewItem
// 		{
// 			public string Name = "New Item Name";
// 			private Item item;

// 			[Button("Save")]
// 			private void CreateObject()
// 			{
// 				item = ScriptableObject.CreateInstance<Item>();
// 				AssetDatabase.CreateAsset(item, $"Assets/ScriptableObjects/Items/{Name}.asset");
// 				AssetDatabase.SaveAssets();
// 				AddNameAttribute();
// 			}

// 			private void AddNameAttribute()
// 			{
// 				var newAttribute = CreateInstance<NameAttribute>();
// 				newAttribute.Value = Name;
// 				newAttribute.hideFlags = HideFlags.HideInHierarchy;
// 				AssetDatabase.AddObjectToAsset(newAttribute, item);
// 				AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(newAttribute));
// 				AssetDatabase.SaveAssets();
// 				AssetDatabase.Refresh();
// 				item.Attributes.Add(newAttribute);
// 			}
// 		}
// 	}
// }
