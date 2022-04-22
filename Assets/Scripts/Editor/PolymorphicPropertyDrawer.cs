using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using JuniperJackal.Extensions;
using System.Linq;

// https://forum.unity.com/threads/custompropertydrawer-for-polymorphic-class.824667/#post-6702670
namespace JuniperJackal
{
	public interface IPolymorphicPropertyDrawerInstance<TScriptableObject> where TScriptableObject : ScriptableObject
	{
		void OnGUI(Rect position, SerializedObject propertyObj, GUIContent label);
		float GetPropertyHeight(SerializedObject propertyObj, GUIContent label);
	}

	public abstract class APolymorphicPropertyDrawer<TScriptableObject, TPropertyDrawer> : PropertyDrawer where TScriptableObject : ScriptableObject where TPropertyDrawer : PropertyDrawer, IPolymorphicPropertyDrawerInstance<TScriptableObject>
	{
		protected static Dictionary<Type, TPropertyDrawer> m_TypeToPropertyDrawerMappings;

		protected void TryInitPropertyMappings()
		{
			if (m_TypeToPropertyDrawerMappings == null)
			{
				m_TypeToPropertyDrawerMappings = new Dictionary<Type, TPropertyDrawer>();
				DoInitPropertyMappings();
			}
		}

		protected abstract void DoInitPropertyMappings();

		protected void RegisterPropertyDrawer(Type type, TPropertyDrawer propertyDrawer)
		{
			// if (type.IsAbstract)
			// {
			// 	throw new Exception($"Unable to register {type.Name} because it is abstract");
			// }

			m_TypeToPropertyDrawerMappings[type] = propertyDrawer;
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			TryInitPropertyMappings();

			// Using BeginProperty / EndProperty on the parent property means that
			// prefab override logic works on the entire property.
			EditorGUI.BeginProperty(position, label, property);

			TPropertyDrawer drawer = GetPropertyDrawer(property);
			if (drawer != null)
			{
				SerializedObject propertyObj = GetSerializedObject(property);
				drawer.OnGUI(position, propertyObj, label);
			}
			else
			{
				EditorGUI.LabelField(position, "Unsupported type");
			}

			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			TryInitPropertyMappings();

			SerializedObject propertyObj = GetSerializedObject(property);
			TPropertyDrawer drawer = GetPropertyDrawer(property);
			if (drawer != null)
			{
				return drawer.GetPropertyHeight(propertyObj, label);
			}

			return EditorGUIUtility.singleLineHeight;
		}

		private SerializedObject GetSerializedObject(SerializedProperty property)
		{
			return new SerializedObject(property.objectReferenceValue);
			// return newObj;
		}

		private TPropertyDrawer GetPropertyDrawer(SerializedProperty property)
		{
			Type propertyType = property.objectReferenceValue.GetType();
			TPropertyDrawer drawer = null;
			var types = propertyType.GetParentTypes().Prepend(propertyType);

			foreach (var t in types)
			{
				if (m_TypeToPropertyDrawerMappings.TryGetValue(t, out drawer))
				{
					break;
				}
			}

			return drawer;
		}
	}
}