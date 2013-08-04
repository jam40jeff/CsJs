using MorseCode.CsJs.Common.Observable;

namespace MorseCode.CsJs.Common.Data
{
	public class PagingInstruction : IPagingInstruction
	{
		private readonly IObservableProperty<int> _pageSize = new ObservableProperty<int>();
		private readonly IObservableProperty<int> _pageIndex = new ObservableProperty<int>();

		public IObservableProperty<int> PageSize
		{
			get { return _pageSize; }
		}

		public IObservableProperty<int> PageIndex
		{
			get { return _pageIndex; }
		}
	}
}