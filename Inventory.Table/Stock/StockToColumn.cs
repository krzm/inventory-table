using DataToTable;
using Inventory.Data;

namespace Inventory.Table;

public abstract class StockToColumn
    : StockToText
{
    public StockToColumn(
		ITableTextEditor tableTextEditor
		, IColumnCalculator<Stock> columnCalculator)
			: base(tableTextEditor, columnCalculator)
	{
	}

    protected List<int> GetIdLength(List<Stock> models)
	{
		var rows = models.Select(m => GetId(m).Length).ToList();
		rows.Insert(0, nameof(Stock.Id).Length);
		return rows;
	}

	protected List<int> GetItemLength(List<Stock> items)
	{
		var rows = items.Select(m => GetItem(m).Length).ToList();
		rows.Insert(0, nameof(Stock.Item).Length);
		return rows;
	}

	protected List<int> GetItemIdLength(List<Stock> models)
	{
		var rows = models.Select(e => GetItemId(e).Length).ToList();
		rows.Insert(0, nameof(Stock.ItemId).Length);
		return rows;
	}
}