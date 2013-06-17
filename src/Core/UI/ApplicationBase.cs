using System;
using System.Collections.Generic;
using System.Html;
using MorseCode.CsJs.Common;
using MorseCode.CsJs.UI.Controls;
using MorseCode.CsJs.ViewModel;

namespace MorseCode.CsJs.UI
{
    public abstract class ApplicationBase
    {
        private readonly Dictionary<Type, ApplicationPage> _applicationPages = new Dictionary<Type, ApplicationPage>();
        private readonly PageRegistrationHelper _pageRegistrationHelper;

        private readonly Lazy<ApplicationViewModelBase> _applicationViewModel;

        private IPage _currentPage;

        protected ApplicationBase()
        {
            _applicationViewModel = new Lazy<ApplicationViewModelBase>(CreateApplicationViewModel);
            _pageRegistrationHelper = new PageRegistrationHelper(this);
        }

        public string Title
        {
            get { return Document.Title; }
            set { Document.Title = value; }
        }

        protected abstract ApplicationViewModelBase CreateApplicationViewModel();

        public void Initialize()
        {
            TimerFactory.Instance = WindowTimerFactory.Instance;

            RegisterPages(_pageRegistrationHelper);

            Window.Onerror = new ErrorHandler(_applicationViewModel.Value.ErrorHandler);
            _applicationViewModel.Value.CurrentViewModel.Changed += CurrentViewModelChanged;
            _applicationViewModel.Value.Initialize();
        }

        private void CurrentViewModelChanged(object sender, EventArgs e)
        {
            if (_currentPage != null)
            {
                _currentPage.Dispose();
                _currentPage = null;
            }

            object currentViewModel = _applicationViewModel.Value.CurrentViewModel.Value;
            if (currentViewModel != null)
            {
                Type currentViewModelType = currentViewModel.GetType();
                if (!_applicationPages.ContainsKey(currentViewModelType))
                {
                    throw new Exception("Could not find a page with view model type " + currentViewModelType.FullName + ".");
                }
                ApplicationPage applicationPage = _applicationPages[currentViewModelType];
                _currentPage = applicationPage.CreatePage();
                Title = _currentPage.Title;
                applicationPage.Bind(_currentPage, currentViewModel);
            }
        }

        protected abstract void RegisterPages(PageRegistrationHelper pageRegistrationHelper);

        public class PageRegistrationHelper
        {
            private readonly ApplicationBase _application;

            internal PageRegistrationHelper(ApplicationBase application)
            {
                _application = application;
            }

            public PageRegistrationHelperStep2<TPage> RegisterPage<TPage>(Func<TPage> createPage) where TPage : class, IPage
            {
                return new PageRegistrationHelperStep2<TPage>(_application, createPage);
            }
        }

        public class PageRegistrationHelperStep2<TPage> where TPage : class, IPage
        {
            private readonly ApplicationBase _application;
            private readonly Func<TPage> _createPage;

            internal PageRegistrationHelperStep2(ApplicationBase application, Func<TPage> createPage)
            {
                _application = application;
                _createPage = createPage;
            }

            public void WithBinding<TDataContext>(Action<TPage, TDataContext> bind)
            {
                _application._applicationPages.Add(typeof (TDataContext), new ApplicationPage(_createPage, (p, d) => bind((TPage) p, (TDataContext) d)));
            }
        }

        private class ApplicationPage
        {
            private readonly Func<IPage> _createPage;
            private readonly Action<IPage, object> _bind;

            public ApplicationPage(Func<IPage> createPage, Action<IPage, object> bind)
            {
                _createPage = createPage;
                _bind = bind;
            }

            public Func<IPage> CreatePage
            {
                get { return _createPage; }
            }

            public Action<IPage, object> Bind
            {
                get { return _bind; }
            }
        }
    }
}