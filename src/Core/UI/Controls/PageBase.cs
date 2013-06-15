using System.Collections.Generic;
using System.Html;
using MorseCode.CsJs.Common.Observable;
using MorseCode.CsJs.ViewModel;

namespace MorseCode.CsJs.UI.Controls
{
    public abstract class PageBase<T> : CompositeControl, IPage
    {
        public void Initialize()
        {
            Bind(CreateViewModel());
        }

        protected override IEnumerable<Element> GetRootElements()
        {
            return new[] { Document.Body };
        }

        protected override Element GetChildElementContainer()
        {
            return Document.Body;
        }

        protected override void CreateElements()
        {
        }

        public void Bind(T dataContext)
        {
            EnsureChildControlsCreated();

            BindControls(new ReadOnlyProperty<T>(dataContext));
        }

        protected abstract void BindControls(IReadableObservableProperty<T> dataContext);

        protected abstract T CreateViewModel();
    }
}