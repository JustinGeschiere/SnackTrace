namespace SnackTrace.Utility.Convert.Attributes
{
	public class ConvertKeyAttribute : ConvertAttribute
	{
		public string Key { get; }

		public ConvertKeyAttribute(string key)
		{
			Key = key;
		}
	}
}
