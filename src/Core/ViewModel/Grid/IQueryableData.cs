using MorseCode.CsJs.Common.Observable;

namespace MorseCode.CsJs.ViewModel.Grid
{
	public interface IQueryableData<T>
	{
		ReadOnlyProperty<ObservableCollection<T>> Data { get; }

		void Execute();
	}
}