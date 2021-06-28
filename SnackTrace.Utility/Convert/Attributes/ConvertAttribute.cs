using System;

namespace SnackTrace.Utility.Convert.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public abstract class ConvertAttribute : Attribute
	{ }
}
