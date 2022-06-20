using DataToTable;
using Inventory.Data;

namespace Inventory.Table;

public class StockTable
    : StockToColumn
{
	public StockTable(
		ITableTextEditor tableTextEditor
		, IColumnCalculator<Stock> columnCalculator)
			: base(tableTextEditor, columnCalculator)
	{
	}

	protected override void CreateTableHeader()
	{
		SetColumns();
	}

	private void SetColumns()
	{
		Editor.AddColumn(GetColumnData(nameof(Stock.Id)));
		Editor.AddColumn(GetColumnData(nameof(Stock.Item)));
		Editor.AddColumn(GetColumnData(nameof(Stock.ItemId)));
	}

	protected override void CreateTableRow(Stock m)
	{
		Editor.AddValue(GetColumnData(nameof(Stock.Id)), GetId(m));
		Editor.AddValue(GetColumnData(nameof(Stock.Item)), GetItem(m));
		Editor.AddValue(GetColumnData(nameof(Stock.ItemId)), GetItemId(m));
	}

	protected override void SetColumnsSize(List<Stock> m)
	{
		SetColumn(nameof(Stock.Id), GetIdLength(m));
		SetColumn(nameof(Stock.Item), GetItemLength(m));
		SetColumn(nameof(Stock.ItemId), GetItemIdLength(m));
	}
}