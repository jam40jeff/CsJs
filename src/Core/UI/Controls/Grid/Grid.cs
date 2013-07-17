using System;
using System.Collections.Generic;
using System.Html;
using System.Xml;
using MorseCode.CsJs.Common.Observable;
using jQueryApi;

namespace MorseCode.CsJs.UI.Controls.Grid
{
    // ReSharper disable RedundantNameQualifier
    [ControlParser(typeof(Grid.Parser))]
    // ReSharper restore RedundantNameQualifier
    public class Grid : ControlBase
    {
        private TableElement _table;
        private Element _header;
        private Element _body;
        private Element _footer;

        public class Parser : ControlParserBase<Grid>
        {
            protected override Grid CreateControl(XmlNode node, Dictionary<string, ControlBase> childControlsById)
            {
                return new Grid();
            }
        }

        protected override void CreateElements()
        {
            _table = (TableElement)jQuery.FromHtml("<table border=\"1\" cellspacing=\"0\" cellpadding=\"5\"><thead></thead><tbody></tbody><tfoot></tfoot></table>")[0];
            _header = GetTHead(_table);
            _body = _table.tBodies[0];
            _footer = _table.tFoot;
        }

        [System.Runtime.CompilerServices.InlineCode("{table}.tHead")]
        private Element GetTHead(TableElement table)
        {
            return null;
        }

        protected override IEnumerable<Element> GetRootElements()
        {
            return new Element[] { _table };
        }

        public void BindData<TDataContext, T>(IReadableObservableProperty<TDataContext> dataContext, Func<TDataContext, IEnumerable<T>> getData, Func<TDataContext, IEnumerable<IGridColumn<T>>> getColumns)
        {
            List<IGridColumn<T>> columns = new List<IGridColumn<T>>();
            List<T> items = new List<T>();

            Action dataBindHeader = () =>
                {
                    Element tableHeader = Document.CreateElement("thead");
                    TableRowElement headerRow = (TableRowElement)Document.CreateElement("tr");
                    tableHeader.AppendChild(headerRow);
                    foreach (IGridColumn<T> column in columns)
                    {
                        Element headerCell = Document.CreateElement("th");
                        headerRow.AppendChild(headerCell);
                        if (!string.IsNullOrEmpty(column.HeaderText))
                        {
                            jQuery.FromElement(headerCell).Text(column.HeaderText);
                        }
                    }
                    _table.ReplaceChild(tableHeader, _header);
                    _header = tableHeader;
                };

            Action dataBindItems = () =>
                {
                    Element tableBody = Document.CreateElement("tbody");
                    int rowIndex = 0;
                    foreach (T item in items)
                    {
                        TableRowElement row = (TableRowElement)Document.CreateElement("tr");
                        tableBody.AppendChild(row);
                        foreach (IGridColumn<T> column in columns)
                        {
                            Element cell = row.InsertCell();
                            IControl cellControl = column.CreateControl(rowIndex, item);
                            cellControl.AddControlTo(cell);
                        }
                        rowIndex++;
                    }
                    _table.ReplaceChild(tableBody, _body);
                    _body = tableBody;
                };

            Action<IEnumerable<T>> setItems = i =>
                {
                    items.Clear();
                    items.AddRange(i);
                    dataBindItems();
                };
            Action<IEnumerable<IGridColumn<T>>> setColumns = c =>
                {
                    columns.Clear();
                    columns.AddRange(c);
                    dataBindHeader();
                    dataBindItems();
                };

            EventHandler updateControlColumnsEventHandler = null;
            CreateOneWayBinding(
                dataContext,
                d =>
                {
                    Action updateControl = () => setColumns(getColumns(d));
                    updateControlColumnsEventHandler = (sender, args) => updateControl();
                    //getTextProperty(d).Changed += updateControlColumnsEventHandler;
                    updateControl();
                },
                d => { });//getTextProperty(d).Changed -= updateControlColumnsEventHandler);

            EventHandler updateControlDataEventHandler = null;
            CreateOneWayBinding(
                dataContext,
                d =>
                {
                    Action updateControl = () => setItems(getData(d));
                    updateControlDataEventHandler = (sender, args) => updateControl();
                    //getTextProperty(d).Changed += updateControlDataEventHandler;
                    updateControl();
                },
                d => { }); //getTextProperty(d).Changed -= updateControlDataEventHandler);
        }
    }
}