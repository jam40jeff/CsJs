using System.Collections;

namespace MorseCode.CsJs.Common.Data
{
	public class PagedResult<T> : IPagedResult<T> where T : IEnumerable
	{
		private readonly T _data;
		private readonly int _totalItems;

		public PagedResult(T data, int totalItems)
		{
			_data = data;
			_totalItems = totalItems;
		}

		public T Data
		{
			get { return _data; }
		}

		public int TotalItems
		{
			get { return _totalItems; }
		}
	}
}