namespace SnackTrace.GraphQL.Entities.Order
{
	public class OrderSnack
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
