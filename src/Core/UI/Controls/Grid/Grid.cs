using System;
using System.Collections.Generic;
using System.Html;
using System.Html.Media.Graphics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using MorseCode.CsJs.Common;
using MorseCode.CsJs.Common.Data;
using MorseCode.CsJs.Common.Observable;
using MorseCode.CsJs.ViewModel.Grid;
using jQueryApi;

namespace MorseCode.CsJs.UI.Controls.Grid
{
	[ControlParser(typeof(Parser))]
	public class Grid : ControlBase
	{
		private TableElement _table;
		private Element _header;
		private Element _body;
		private Element _footer;

		private IBinding _columnsBinding;
		private IBinding _dataBinding;

		private readonly List<IBinding> _headerBindings = new List<IBinding>();
		private readonly List<IBinding> _footerBindings = new List<IBinding>();
		private ControlCollection _footerControls;

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

		[InlineCode("{table}.tHead")]
		private Element GetTHead(TableElement table)
		{
			return null;
		}

		protected override IEnumerable<Element> GetRootElements()
		{
			return new Element[] { _table };
		}

		public void BindData<TDataContext, T>(IReadableObservableProperty<TDataContext> dataContext, T dummyItem, Func<TDataContext, IReadOnlyProperty<IEnumerable<T>>> getData, Func<TDataContext, IReadOnlyProperty<IEnumerable<IGridColumn<T>>>> getColumns)
		{
			BindDataInternal(dataContext, dummyItem, getData, null, null, getColumns);
		}

		public void BindData<TDataContext, T>(IReadableObservableProperty<TDataContext> dataContext, T dummyItem, Func<TDataContext, IReadOnlyProperty<IQueryableData<T>>> getData, Func<TDataContext, IReadOnlyProperty<IEnumerable<IGridColumn<T>>>> getColumns)
		{
			BindDataInternal(dataContext, dummyItem, d => getData(d).Value.Data, null, null, getColumns);
		}

		public void BindDataWithSorting<TDataContext, T, TQueryableData>(IReadableObservableProperty<TDataContext> dataContext, T dummyItem, Func<TDataContext, IReadOnlyProperty<TQueryableData>> getData, Func<TDataContext, IReadOnlyProperty<IEnumerable<IGridColumn<T>>>> getColumns) where TQueryableData : class,IQueryableData<T>, ISortableData<T>
		{
			BindDataInternal(dataContext, dummyItem, d => getData(d).Value.Data, getData, null, getColumns);
		}

		public void BindDataWithPaging<TDataContext, T, TQueryableData>(IReadableObservableProperty<TDataContext> dataContext, T dummyItem, Func<TDataContext, IReadOnlyProperty<TQueryableData>> getData, Func<TDataContext, IReadOnlyProperty<IEnumerable<IGridColumn<T>>>> getColumns) where TQueryableData : class,IQueryableData<T>, IPageableData
		{
			BindDataInternal(dataContext, dummyItem, d => getData(d).Value.Data, null, getData, getColumns);
		}

		public void BindDataWithSortingAndPaging<TDataContext, T, TQueryableData>(IReadableObservableProperty<TDataContext> dataContext, T dummyItem, Func<TDataContext, IReadOnlyProperty<TQueryableData>> getData, Func<TDataContext, IReadOnlyProperty<IEnumerable<IGridColumn<T>>>> getColumns) where TQueryableData : class,IQueryableData<T>, ISortableData<T>, IPageableData
		{
			BindDataInternal(dataContext, dummyItem, d => getData(d).Value.Data, getData, getData, getColumns);
		}

		private void BindDataInternal<TDataContext, T>(IReadableObservableProperty<TDataContext> dataContext, T dummyItem, Func<TDataContext, IReadOnlyProperty<IEnumerable<T>>> getData, Func<TDataContext, IReadOnlyProperty<ISortableData<T>>> getSortableData, Func<TDataContext, IReadOnlyProperty<IPageableData>> getPageableData, Func<TDataContext, IReadOnlyProperty<IEnumerable<IGridColumn<T>>>> getColumns)
		{
			EnsureUnbound(_columnsBinding);
			EnsureUnbound(_dataBinding);

			List<IGridColumn<T>> columns = new List<IGridColumn<T>>();
			List<T> items = new List<T>();

			Action<TDataContext> dataBindHeader = d =>
				{
					foreach (IBinding headerBinding in _headerBindings)
					{
						RemoveBinding(headerBinding);
					}
					_headerBindings.Clear();

					Element tableHeader = Document.CreateElement("thead");
					TableRowElement headerRow = (TableRowElement)Document.CreateElement("tr");
					tableHeader.AppendChild(headerRow);
					foreach (IGridColumn<T> column in columns)
					{
						Element headerCell = Document.CreateElement("th");
						headerRow.AppendChild(headerCell);

						IGridBoundColumn<T> boundColumn = column as IGridBoundColumn<T>;
						string headerText = column.HeaderText;
						if (boundColumn != null)
						{
							if (headerText == null)
							{
								headerText = boundColumn.PropertyExpression.PropertyName;
							}
						}
						if (headerText == null)
						{
							headerText = string.Empty;
						}

						Element headerTextSpan = Document.CreateElement("span");
						headerCell.AppendChild(headerTextSpan);
						jQueryObject headerTextSpanJQueryObject = jQuery.FromElement(headerTextSpan);
						headerTextSpanJQueryObject.Text(headerText);

						if (boundColumn != null)
						{
							jQueryObject headerCellJQueryObject = jQuery.FromElement(headerCell);
							if (getSortableData != null)
							{
								headerTextSpan.Style.Cursor = "pointer";

								CanvasElement canvas = (CanvasElement)Document.CreateElement("canvas");
								jQueryObject canvasJQueryObject = jQuery.FromElement(canvas);
								canvas.Width = 8;
								canvas.Height = 8;
								canvas.Style.PaddingLeft = "5px";
								canvas.Style.Cursor = "pointer";
								headerCell.AppendChild(canvas);
								CanvasContext context = canvas.GetContext(Rendering.Render2D);

								headerTextSpanJQueryObject.MouseEnter(e => headerTextSpan.Style.TextDecoration = "underline").MouseLeave(e => headerTextSpan.Style.TextDecoration = "none");
								canvasJQueryObject.MouseEnter(e => headerTextSpan.Style.TextDecoration = "underline").MouseLeave(e => headerTextSpan.Style.TextDecoration = "none");

								SortDirection? sortDirection = null;

								Action setSortExpression = () => getSortableData(d).Value.ColumnSortExpressions.Value.Reset(new[] { ColumnSortExpressionFactory<T>.CreateSortExpression(boundColumn.UniqueName, dummyItem, boundColumn.PropertyExpression, sortDirection == SortDirection.Ascending ? SortDirection.Descending : SortDirection.Ascending) });
								headerCellJQueryObject.Click(e => setSortExpression());
								canvasJQueryObject.Click(e => setSortExpression());

								EventHandler updateControlSortIndicatorEventHandler = null;
								IBinding sortIndicatorBinding = CreateOneWayBinding(dataContext, d2 =>
									{
										Action updateControl = () =>
											{
												Action clear = () => context.ClearRect(0, 0, 8, 8);
												IColumnSortExpression<T> columnSortExpression = getSortableData(d2).Value.ColumnSortExpressions.Value.FirstOrDefault(s => s.ColumnUniqueName == boundColumn.UniqueName);
												if (columnSortExpression == null)
												{
													if (sortDirection != null)
													{
														sortDirection = null;

														clear();
													}
												}
												else
												{
													if (columnSortExpression.SortExpression.SortDirection == SortDirection.Descending)
													{
														if (sortDirection != SortDirection.Descending)
														{
															sortDirection = SortDirection.Descending;

															clear();
															context.BeginPath();
															context.MoveTo(0, 0);
															context.LineTo(8, 0);
															context.LineTo(4, 8);
															context.ClosePath();
															context.SetFillStyle("#999999");
															context.Fill();
														}
													}
													else
													{
														if (sortDirection != SortDirection.Ascending)
														{
															sortDirection = SortDirection.Ascending;

															clear();
															context.BeginPath();
															context.MoveTo(0, 8);
															context.LineTo(8, 8);
															context.LineTo(4, 0);
															context.ClosePath();
															context.SetFillStyle("#999999");
															context.Fill();
														}
													}
												}
											};
										updateControlSortIndicatorEventHandler = (sender, args) => updateControl();
										getSortableData(d2).Value.ColumnSortExpressions.Value.Changed += updateControlSortIndicatorEventHandler;
										updateControl();
									}, d2 => getSortableData(d2).Value.ColumnSortExpressions.Value.Changed -= updateControlSortIndicatorEventHandler);
								AddBinding(sortIndicatorBinding);
								_headerBindings.Add(sortIndicatorBinding);
							}
						}
					}
					_table.ReplaceChild(tableHeader, _header);
					_header = tableHeader;
				};

			Action<TDataContext> dataBindFooter = d =>
				{
					foreach (IBinding footerBinding in _footerBindings)
					{
						RemoveBinding(footerBinding);
					}
					_footerBindings.Clear();

					if (_footerControls != null)
					{
						_footerControls.ForEach(c => c.Dispose());
						_footerControls = null;
					}

					if (getPageableData != null)
					{
						Element tableFooter = Document.CreateElement("tfoot");
						TableRowElement footerRow = (TableRowElement)Document.CreateElement("tr");
						tableFooter.AppendChild(footerRow);
						if (columns.Count > 0)
						{
							TableCellElement footerCell = (TableCellElement)Document.CreateElement("td");
							footerCell.ColSpan = columns.Count;
							footerRow.AppendChild(footerCell);

							_footerControls = new ControlCollection(() => footerCell);

							Button firstButton = new Button();
							firstButton.SetText("<<");
							firstButton.BindClickAction(dataContext, d2 => () => getPageableData(d2).Value.PagingInstruction.Value.PageIndex.Value = 0);
							firstButton.BindEnabled(dataContext, d2 => getPageableData(d2).Value.CanMovePrevious);
							_footerControls.Add(firstButton);

							Button previousButton = new Button();
							previousButton.SetText("<");
							previousButton.BindClickAction(dataContext, d2 => () => getPageableData(d2).Value.PagingInstruction.Value.PageIndex.Value--);
							previousButton.BindEnabled(dataContext, d2 => getPageableData(d2).Value.CanMovePrevious);
							_footerControls.Add(previousButton);

							Button nextButton = new Button();
							nextButton.SetText(">");
							nextButton.BindClickAction(dataContext, d2 => () => getPageableData(d2).Value.PagingInstruction.Value.PageIndex.Value++);
							nextButton.BindEnabled(dataContext, d2 => getPageableData(d2).Value.CanMoveNext);
							_footerControls.Add(nextButton);

							Button lastButton = new Button();
							lastButton.SetText(">>");
							lastButton.BindClickAction(dataContext, d2 => () => getPageableData(d2).Value.PagingInstruction.Value.PageIndex.Value = getPageableData(d2).Value.TotalPages.Value - 1);
							lastButton.BindEnabled(dataContext, d2 => getPageableData(d2).Value.CanMoveNext);
							_footerControls.Add(lastButton);

							Label pageIndexPrefixLabel = new Label();
							pageIndexPrefixLabel.Styles.AddOrSet("margin-left", "15px");
							pageIndexPrefixLabel.SetText("Page: ");
							_footerControls.Add(pageIndexPrefixLabel);

							Label pageIndexLabel = new Label();
							pageIndexLabel.BindText(dataContext, d2 => getPageableData(d2).Value.PagingInstruction.Value.PageIndex, o => (o + 1).ToString());
							_footerControls.Add(pageIndexLabel);

							Label totalPagesPrefixLabel = new Label();
							totalPagesPrefixLabel.SetText(" of ");
							_footerControls.Add(totalPagesPrefixLabel);

							Label totalPagesLabel = new Label();
							totalPagesLabel.BindText(dataContext, d2 => getPageableData(d2).Value.TotalPages, o => o.ToString());
							_footerControls.Add(totalPagesLabel);
						}
						_table.ReplaceChild(tableFooter, _footer);
						_footer = tableFooter;
					}
					else
					{
						if (_footer != null)
						{
							_table.RemoveChild(_footer);
							_footer = null;
						}
					}
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
							Element cell = Document.CreateElement("td");
							row.AppendChild(cell);
							IControl cellControl = column.CreateControl(rowIndex, new ReadOnlyProperty<T>(item));
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
			Action<TDataContext, IEnumerable<IGridColumn<T>>> setColumns = (d, c) =>
				{
					List<IGridColumn<T>> newColumns = c.ToList();

					if (newColumns.Any(column => string.IsNullOrEmpty(column.UniqueName)))
					{
						throw new Exception("All columns must specify a UniqueName.");
					}

					Lookup<string, IGridColumn<T>> columnsByUniqueName = newColumns.ToLookup(column => column.UniqueName);
					if (columnsByUniqueName.Any(columnCount => columnCount.Count() > 1))
					{
						throw new Exception("Column UniqueNames must be unique.");
					}

					columns.Clear();
					columns.AddRange(newColumns);
					dataBindHeader(d);
					dataBindFooter(d);
					dataBindItems();
				};

			EventHandler updateControlColumnsEventHandler = null;
			_columnsBinding = CreateOneWayBinding(
				dataContext,
				d =>
				{
					IEnumerable<IGridColumn<T>> thisColumns = getColumns(d).Value;
					Action updateControl = () => setColumns(d, thisColumns);
					updateControlColumnsEventHandler = (sender, args) => updateControl();
					IObservableCollection<IGridColumn<T>> observableColumns = thisColumns as IObservableCollection<IGridColumn<T>>;
					if (observableColumns != null)
					{
						observableColumns.Changed += updateControlColumnsEventHandler;
					}
					updateControl();
				},
				d =>
				{
					IEnumerable<IGridColumn<T>> thisColumns = getColumns(d).Value;
					IObservableCollection<IGridColumn<T>> observableColumns = thisColumns as IObservableCollection<IGridColumn<T>>;
					if (observableColumns != null)
					{
						observableColumns.Changed -= updateControlColumnsEventHandler;
					}
				});
			AddBinding(_columnsBinding);

			EventHandler updateControlDataEventHandler = null;
			_dataBinding = CreateOneWayBinding(
				dataContext,
				d =>
				{
					IEnumerable<T> thisItems = getData(d).Value;
					Action updateControl = () => setItems(thisItems);
					updateControlDataEventHandler = (sender, args) => updateControl();
					IObservableCollection<T> observableItems = thisItems as IObservableCollection<T>;
					if (observableItems != null)
					{
						//TODO: optimize
						observableItems.Changed += updateControlDataEventHandler;
					}
					updateControl();
				},
				d =>
				{
					IEnumerable<T> thisItems = getData(d).Value;
					IObservableCollection<T> observableItems = thisItems as IObservableCollection<T>;
					if (observableItems != null)
					{
						observableItems.Changed -= updateControlDataEventHandler;
					}
				});
			AddBinding(_dataBinding);
		}
	}
}