using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackTrace.Utility
{
	public static class Materializer
	{
		public static void Materialize(this IEnumerable<object> enumerable)
		{
			enumerable.Count();
		}

		public static async Task MaterializeAsync(this IEnumerable<object> enumerable)
		{
			await Task.Run(() => enumerable.Materialize());
		}
	}
}
