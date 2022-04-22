using System;
using System.Collections.Generic;
using System.Linq;

namespace JuniperJackal.Extensions
{
	// https://stackoverflow.com/a/18375526
	public static class TypeExtensions
	{
		public static bool IsAssignableFromGenericType(this Type genericType, Type givenType)
		{
			return IsAssignableToGenericType(givenType, genericType);
		}

		public static bool IsAssignableToGenericType(this Type givenType, Type genericType)
		{
			var interfaceTypes = givenType.GetInterfaces();

			foreach (var it in interfaceTypes)
			{
				if (it.IsGenericType && it.GetGenericTypeDefinition() == genericType)
					return true;
			}

			if (givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
				return true;

			Type baseType = givenType.BaseType;
			if (baseType == null) return false;

			return IsAssignableToGenericType(baseType, genericType);
		}

		public static bool InheritsFrom(this Type type, Type baseType)
		{
			// null does not have base type
			if (type == null)
			{
				return false;
			}

			// only interface or object can have null base type
			if (baseType == null)
			{
				return type.IsInterface || type == typeof(object);
			}

			// check implemented interfaces
			if (baseType.IsInterface)
			{
				return type.GetInterfaces().Contains(baseType);
			}

			// check all base types
			var currentType = type;
			while (currentType != null)
			{
				if (currentType.BaseType == baseType)
				{
					return true;
				}

				currentType = currentType.BaseType;
			}

			return false;
		}

		public static IEnumerable<Type> GetParentTypes(this Type type)
		{
			// is there any base type?
			if (type == null)
			{
				yield break;
			}

			// return all implemented or inherited interfaces
			foreach (var i in type.GetInterfaces())
			{
				yield return i;
			}

			// return all inherited types
			var currentBaseType = type.BaseType;
			while (currentBaseType != null)
			{
				yield return currentBaseType;
				currentBaseType = currentBaseType.BaseType;
			}
		}
	}
}
