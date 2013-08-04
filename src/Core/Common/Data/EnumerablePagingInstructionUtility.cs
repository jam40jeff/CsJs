using System.Collections.Generic;
using System.Linq;

namespace MorseCode.CsJs.Common.Data
{
	public static class EnumerablePagingInstructionUtility
	{
		public static IEnumerable<T> Apply<T>(IEnumerable<T> data, IPagingInstruction pagingInstruction)
		{
			if (data == null || pagingInstruction == null || pagingInstruction.PageSize.Value < 1)
			{
				return data;
			}

			int pageIndex = pagingInstruction.PageIndex.Value;
			if (pageIndex < 0)
			{
				pageIndex = 0;
			}
			int pageSize = pagingInstruction.PageSize.Value;
			return data.Skip(pageSize * pageIndex).Take(pageSize);
		}
	}
}