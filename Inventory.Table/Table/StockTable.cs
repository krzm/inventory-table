using DataToTable;
using Inventory.Data;

namespace Inventory.Table;

public class StockTable : TextTable<Stock>
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
		Editor.AddColumn(GetColumnData(nameof(Stock.Container)));
		Editor.AddColumn(GetColumnData(nameof(Stock.ContainerId)));
	}

	protected override void CreateTableRow(Stock e)
	{
		Editor.AddValue(GetColumnData(nameof(Stock.Id)), GetId(e));
		Editor.AddValue(GetColumnData(nameof(Stock.Item)), GetItem(e));
		Editor.AddValue(GetColumnData(nameof(Stock.ItemId)), GetItemId(e));
		Editor.AddValue(GetColumnData(nameof(Stock.Container)), GetContainer(e));
		Editor.AddValue(GetColumnData(nameof(Stock.ContainerId)), GetContainerId(e));
	}

	private static string GetId(Stock e) => e.Id.ToString();

	private static string GetItem(Stock e) => e.Item != null ? e.Item.Name : "";

	private static string GetItemId(Stock e) => e.ItemId.ToString();

	private static string GetContainer(Stock e) => e.Container.Name;

	private static string GetContainerId(Stock e) => e.ContainerId.ToString();

	protected override void SetColumnsSize(List<Stock> paths)
	{
		SetColumn(nameof(Stock.Id), GetIdLength(paths));
		SetColumn(nameof(Stock.Item), GetItemLength(paths));
		SetColumn(nameof(Stock.ItemId), GetItemIdLength(paths));
		SetColumn(nameof(Stock.Container), GetContainerLength(paths));
		SetColumn(nameof(Stock.ContainerId), GetContainerIdLength(paths));
	}

	private static List<int> GetIdLength(List<Stock> models)
	{
		var rows = models.Select(e => GetId(e).Length).ToList();
		rows.Insert(0, nameof(Stock.Id).Length);
		return rows;
	}

	private static List<int> GetItemLength(List<Stock> items)
	{
		var rows = items.Select(e => GetItem(e).Length).ToList();
		rows.Insert(0, nameof(Stock.Item).Length);
		return rows;
	}

	private static List<int> GetItemIdLength(List<Stock> models)
	{
		var rows = models.Select(e => GetItemId(e).Length).ToList();
		rows.Insert(0, nameof(Stock.ItemId).Length);
		return rows;
	}

	private static List<int> GetContainerLength(List<Stock> models)
	{
		var rows = models.Select(e => GetContainer(e).Length).ToList();
		rows.Insert(0, nameof(Stock.Container).Length);
		return rows;
	}

	private static List<int> GetContainerIdLength(List<Stock> models)
	{
		var rows = models.Select(e => GetContainerId(e).Length).ToList();
		rows.Insert(0, nameof(Stock.ContainerId).Length);
		return rows;
	}
}