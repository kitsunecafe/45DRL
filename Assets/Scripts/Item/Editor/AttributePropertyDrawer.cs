using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using JuniperJackal.Extensions;
using UnityEditor;
using UnityEngine;

namespace JuniperJackal.Entity
{
	[CustomPropertyDrawer(typeof(ItemAttribute), true)]
	public class ItemAttributeDrawer : APolymorphicPropertyDrawer<ItemAttribute, BaseItemAttributeDrawer>
	{
		protected override void DoInitPropertyMappings()
		{
			var allAttributes = Assembly.GetAssembly(typeof(ItemAttribute))
				.GetTypes()
				.Where(typeof(ItemAttribute).IsAssignableFrom);

			var baseDrawer = new BaseItemAttributeDrawer();

			foreach (var attribute in allAttributes)
			{
				RegisterPropertyDrawer(attribute, baseDrawer);
			}

			var valueAttributes = allAttributes.Where(typeof(ValueAttribute<>).IsAssignableFromGenericType).ToArray();

			var valueDrawer = new ValueAttributeDrawer();
			foreach (var attribute in valueAttributes)
			{
				RegisterPropertyDrawer(attribute, valueDrawer);
			}

			RegisterPropertyDrawer(typeof(SpriteAttribute), new SpriteAttributeDrawer());
		}

		private static bool IsConcrete(Type type, Type generic)
		{
			return !type.IsAbstract
				&& !type.IsInterface
				&& type.BaseType != null
				&& type.BaseType.IsGenericType
				&& type.BaseType.GetGenericTypeDefinition() == generic;
		}
	}

	public class BaseItemAttributeDrawer : PropertyDrawer, IPolymorphicPropertyDrawerInstance<ItemAttribute>
	{
		protected static readonly float SinglePropertyHeight = EditorGUIUtility.singleLineHeight;

		public virtual float GetPropertyHeight(SerializedObject propertyObj, GUIContent label)
		{
			return SinglePropertyHeight;
		}

		public void OnGUI(Rect position, SerializedObject propertyObj, GUIContent label)
		{
			propertyObj.UpdateIfRequiredOrScript();

			var nameRect = new Rect(position.xMin, position.yMin, position.width, SinglePropertyHeight);

			var attribute = propertyObj.targetObject as ItemAttribute;
			var attributeName = attribute.GetType().Name;
			var description = attribute.EditorDescription;
			var attributeLabel = new GUIContent(FormatTitleCase(attributeName), description);

			var remainingRect = new Rect(position.xMin, nameRect.yMin, position.width, SinglePropertyHeight);

			DrawGUI(remainingRect, propertyObj, attributeLabel);

			propertyObj.ApplyModifiedProperties();
		}

		private static string FormatTitleCase(string value)
		{
			return SpaceTitleCase(TrimEnd(value, "Attribute", "Property"));
		}

		private static string TrimEnd(string value, string end)
		{
			return value.EndsWith(end) ? value.Substring(0, value.Length - end.Length) : value;
		}

		private static string TrimEnd(string value, params string[] end)
		{
			return end.Aggregate(value, (acc, current) => TrimEnd(acc, current));
		}

		private static string SpaceTitleCase(string value)
		{
			return Regex.Replace(value, "(\\B[A-Z])", " $1");
		}

		protected virtual void DrawGUI(Rect position, SerializedObject propertyObj, GUIContent label)
		{
			EditorGUI.LabelField(position, label);
		}
	}

	public class ValueAttributeDrawer : BaseItemAttributeDrawer
	{
		protected const string ValuePropertyName = nameof(TextAttribute.Value);

		protected override void DrawGUI(Rect position, SerializedObject propertyObj, GUIContent label)
		{
			var rect = new Rect(position.xMin, position.yMin, position.width, SinglePropertyHeight);
			var valueProp = propertyObj.FindProperty(ValuePropertyName);

			EditorGUI.PropertyField(position, valueProp, label, true);
		}
	}

	public class SpriteAttributeDrawer : ValueAttributeDrawer
	{
		private const int ObjectFieldHeight = 64;
		public override float GetPropertyHeight(SerializedObject propertyObj, GUIContent label)
		{
			return base.GetPropertyHeight(propertyObj, label) + (ObjectFieldHeight - SinglePropertyHeight);
		}

		protected override void DrawGUI(Rect position, SerializedObject propertyObj, GUIContent label)
		{
			var rect = new Rect(position.xMax - ObjectFieldHeight, position.y, ObjectFieldHeight, ObjectFieldHeight);
			var valueProp = propertyObj.FindProperty(ValuePropertyName);

			EditorGUI.PrefixLabel(position, label);
			EditorGUI.ObjectField(rect, valueProp, typeof(Sprite), GUIContent.none);
		}
	}
}
