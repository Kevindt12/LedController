using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedController.Shared.Extensions
{
	public static class AsyncEnumerableExtensions
	{



		public static async Task<IEnumerable<T>> AsEnumerableAsync<T>(this IAsyncEnumerable<T> enumerable, CancellationToken token = default)
		{
			List<T> list = new	List<T>();

			await foreach (T item in enumerable.WithCancellation(token))
			{
				list.Add(item);
			}

			return list;
		}


	}
}
