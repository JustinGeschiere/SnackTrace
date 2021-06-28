namespace SnackTrace.GraphQL.Entities.Order
{
	public class OrderMenu
	{
		public enum Options
		{
			Name,
			Price,
			Created,
			Modified
		}

		public Options Option { get; set; }

		public OrderDirection Direction { get; set; }
	}
}
