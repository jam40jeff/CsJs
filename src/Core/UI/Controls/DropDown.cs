using System;
using System.Collections.Generic;
using System.Html;
using System.Linq;
using System.Xml;
using MorseCode.CsJs.Common.Observable;
using jQueryApi;

namespace MorseCode.CsJs.UI.Controls
{
    // ReSharper disable RedundantNameQualifier
    [ControlParser(typeof(DropDown.Parser))]
    // ReSharper restore RedundantNameQualifier
    public class DropDown : ControlBase
    {
        private readonly ObservableCollection<DropDownItem> _items;

        private SelectElement _select;

        private readonly Styles _styles = new Styles();

        public DropDown()
        {
            _items = new ObservableCollection<DropDownItem>();
            _items.Changed += (sender, args) => OnItemsChanged();
        }

        protected override void CreateElements()
        {
            _select = (SelectElement)Document.CreateElement("select");
            _styles.AttachToElement(_select);
            jQuery.FromElement(_select).Change(e => OnSelectedIndexChanged());
        }

        protected override IEnumerable<Element> GetRootElements()
        {
            return new[] { _select };
        }

        public Styles Styles
        {
            get { return _styles; }
        }

        public ObservableCollection<DropDownItem> Items
        {
            get { return _items; }
        }

        private void OnItemsChanged()
        {
            EnsureElementsCreated();
            while (_select.Options.Length > 0)
            {
                _select.Remove(0);
            }
            foreach (DropDownItem item in _items)
            {
                OptionElement option = (OptionElement)Document.CreateElement("option");
                option.Text = item.Text;
                option.Value = item.Value;
                _select.Add(option);
            }
        }

        public int SelectedIndex
        {
            get
            {
                EnsureElementsCreated();
                return _select.SelectedIndex;
            }
            set
            {
                EnsureElementsCreated();
                if (_select.SelectedIndex != value)
                {
                    _select.SelectedIndex = value;
                    OnSelectedIndexChanged();
                }
            }
        }

        public event EventHandler SelectedIndexChanged;

        protected void OnSelectedIndexChanged()
        {
            if (SelectedIndexChanged != null)
            {
                SelectedIndexChanged(this, EventArgs.Empty);
            }
        }

        public void BindItemsAndSelection<TDataContext, T>(IReadableObservableProperty<TDataContext> dataContext, Func<TDataContext, ObservableCollection<T>> getItems, Func<TDataContext, IObservableProperty<T?>> getSelectedItemProperty, Func<T, string> getValue, Func<T, string> getText) where T : struct
        {
            EventHandler updateControlItemsEventHandler = null;
            CreateOneWayBinding(
                dataContext,
                d =>
                {
                    Action updateControl = () =>
                    {
                        Items.Clear();
                        Items.AddRange(getItems(d).Select(i => new DropDownItem(getText(i), getValue(i))));
                    };
                    updateControlItemsEventHandler = (sender, args) => updateControl();
                    getItems(d).Changed += updateControlItemsEventHandler;
                    updateControl();
                },
                d => getItems(d).Changed -= updateControlItemsEventHandler);

            EventHandler updateDataContextSelectedItemEventHandler = null;
            EventHandler updateControlSelectedItemEventHandler = null;
            CreateTwoWayBinding(
                dataContext,
                d =>
                {
                    Action updateControl = () =>
                    {
                        T? selectedItem = getSelectedItemProperty(d).Value;
                        SelectedIndex = selectedItem == null ? -1 : getItems(d).IndexOf(selectedItem.Value);
                    };
                    updateControlSelectedItemEventHandler = (sender, args) => updateControl();
                    getSelectedItemProperty(d).Changed += updateControlSelectedItemEventHandler;
                    updateControl();
                },
                d => getSelectedItemProperty(d).Changed -= updateControlSelectedItemEventHandler,
                d =>
                {
                    updateDataContextSelectedItemEventHandler = (sender, args) =>
                    {
                        ObservableCollection<T> items = getItems(d);
                        int selectedIndex = SelectedIndex;
                        if (selectedIndex >= 0 && selectedIndex < items.Count)
                        {
                            getSelectedItemProperty(d).Value = items[selectedIndex];
                        }
                        else
                        {
                            getSelectedItemProperty(d).Value = null;
                        }
                    };
                    SelectedIndexChanged += updateDataContextSelectedItemEventHandler;
                },
                d => SelectedIndexChanged -= updateDataContextSelectedItemEventHandler);
        }

        public void BindItemsAndSelection<TDataContext, T>(IReadableObservableProperty<TDataContext> dataContext, Func<TDataContext, ObservableCollection<T>> getItems, Func<TDataContext, IObservableProperty<T>> getSelectedItemProperty, Func<T, string> getValue, Func<T, string> getText) where T : class
        {
            Action<TDataContext> updateItems = d =>
                {
                    Items.Clear();
                    Items.AddRange(getItems(dataContext.Value).Select(i => new DropDownItem(getText(i), getValue(i))));
                };
            Action<TDataContext> updateSelectedIndex = d => SelectedIndex = getItems(dataContext.Value).IndexOf(getSelectedItemProperty(dataContext.Value).Value);
            getItems(dataContext.Value).Changed += (sender, args) => updateItems(dataContext.Value);
            getSelectedItemProperty(dataContext.Value).Changed += (sender, args) => updateSelectedIndex(dataContext.Value);

            SelectedIndexChanged += (sender, args) =>
                {
                    ObservableCollection<T> items = getItems(dataContext.Value);
                    int selectedIndex = SelectedIndex;
                    if (selectedIndex >= 0 && selectedIndex < items.Count)
                    {
                        getSelectedItemProperty(dataContext.Value).Value = items[selectedIndex];
                    }
                    else
                    {
                        getSelectedItemProperty(dataContext.Value).Value = null;
                    }
                };

            updateItems(dataContext.Value);
            updateSelectedIndex(dataContext.Value);
        }

        public class Parser : ControlParserBase<DropDown>
        {
            protected override DropDown CreateControl(XmlNode node, Dictionary<string, ControlBase> childControlsById)
            {
                return new DropDown();
            }

            protected override void ParseAttributeAfterSkin(string name, string value, Dictionary<string, ControlBase> childControlsById, Action<Action<DropDown>> addPostSkinAction)
            {
                base.ParseAttributeAfterSkin(name, value, childControlsById, addPostSkinAction);

                if (name.ToLower() == "style")
                {
                    addPostSkinAction(control => control.Styles.ParseStyleString(value));
                }
            }
        }
    }

    public class DropDownItem
    {
        private readonly string _text;
        private readonly string _value;

        public DropDownItem(string text, string value)
        {
            _text = text;
            _value = value;
        }

        public string Text
        {
            get { return _text; }
        }

        public string Value
        {
            get { return _value; }
        }
    }
}