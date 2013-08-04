using System.Collections;

namespace MorseCode.CsJs.Common.Data
{
	public interface IPagedResult<out T> where T : IEnumerable
	{
		T Data { get; }
		int TotalItems { get; }
	}
}