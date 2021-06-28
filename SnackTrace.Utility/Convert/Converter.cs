using SnackTrace.Utility.Convert.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SnackTrace.Utility.Convert
{
	public static class Converter
	{
		public static T ConvertTo<T>(this object input) where T : new()
		{
			var output = new T();

			var outputFields = output.GetType().GetFields().Where(i => !i.ShouldIgnore());
			var outputProperties = output.GetType().GetProperties().Where(i => !i.ShouldIgnore());

			var inputFields = input.GetType().GetFields().Where(i => !i.ShouldIgnore());
			var inputProperties = input.GetType().GetProperties().Where(i => !i.ShouldIgnore());

			foreach(var outputField in outputFields)
			{
				// Get first matching conversion field
				var inputField = inputFields.FirstOrDefault(i => i.GetConvertKey().Equals(outputField.GetConvertKey()));

				// Skip field if no matching input field is found
				if (inputField == null || inputField.FieldType != outputField.FieldType)
				{
					continue;
				}

				// Assign input field's value to output field
				outputField.SetValue(output, inputField.GetValue(input));
			}

			foreach (var outputProperty in outputProperties)
			{
				// Get first matching conversion property
				var inputProperty = inputProperties.FirstOrDefault(i => i.GetConvertKey().Equals(outputProperty.GetConvertKey()));

				// Skip property if no matching input property is found or if types don't match
				if (inputProperty == null || inputProperty.PropertyType != outputProperty.PropertyType)
				{
					continue;
				}

				// Assign input property's value to output property
				outputProperty.SetValue(output, inputProperty.GetValue(input));
			}

			return output;
		}

		public static Tout ConvertTo<Tin,Tout>(this Tin input, Action<Tin, Tout> customAction) where Tout : new()
		{
			var result = input.ConvertTo<Tout>();
			customAction(input, result);

			return result;
		}

		public static IEnumerable<T> ConvertEachTo<T>(this IEnumerable<object> input) where T : new()
		{
			foreach(var item in input)
			{
				yield return item.ConvertTo<T>();
			}
		}

		public static IEnumerable<Tout> ConvertEachTo<Tin,Tout>(this IEnumerable<Tin> input, Action<Tin,Tout> customAction) where Tout : new() 
		{
			foreach (var item in input)
			{
				var result = item.ConvertTo<Tout>();
				customAction(item, result);

				yield return result;
			}
		}

		private static string GetConvertKey(this MemberInfo member)
		{
			// Get key from convert attribute or default to member name
			return member.GetCustomAttribute<ConvertKeyAttribute>()?.Key ?? member.Name;
		}

		private static bool ShouldIgnore(this MemberInfo member)
		{
			return (member.GetCustomAttribute<ConvertIgnoreAttribute>() != null);
		}
	}
}
