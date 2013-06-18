using System.Collections.Generic;
using System.Html;
using MorseCode.CsJs.Common.Observable;

namespace MorseCode.CsJs.UI.Controls
{
    public abstract class PageBase<T> : CompositeControlBase, IPage
    {
        public abstract string Title { get; }

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

        public void BindDataContext(T dataContext)
        {
            EnsureChildControlsCreated();

            BindControls(new ReadOnlyProperty<T>(dataContext));
        }

        protected abstract void BindControls(IReadableObservableProperty<T> dataContext);
    }
}