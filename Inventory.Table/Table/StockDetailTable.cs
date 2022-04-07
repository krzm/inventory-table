using DataToTable;
using Inventory.Data;

namespace Inventory.Table;

public class StockDetailTable
	: TextTable<StockDetail>
{
    private const string Empty = "";

    public StockDetailTable(
		ITableTextEditor tableTextEditor
		, IColumnCalculator<StockDetail> columnCalculator)
			: base(tableTextEditor, columnCalculator)
	{
	}

	protected override void CreateTableHeader()
	{
		SetColumns();
	}

	private void SetColumns()
	{
		Editor.AddColumn(GetColumnData(nameof(StockDetail.Id)));
		Editor.AddColumn(GetColumnData(nameof(StockDetail.Description)));
	}

	protected override void CreateTableRow(StockDetail e)
	{
		Editor.AddValue(GetColumnData(nameof(StockDetail.Id)), GetId(e));
		Editor.AddValue(GetColumnData(nameof(StockDetail.Description)), GetDescription(e));
	}

	private static string GetId(StockDetail e) => e.Id.ToString();

	private static string GetDescription(StockDetail e) =>
		string.IsNullOrWhiteSpace(e.Description) == false ? e.Description.ToString() : Empty;

	protected override void SetColumnsSize(List<StockDetail> paths)
	{
		SetColumn(nameof(StockDetail.Id), GetIdsLength(paths));
		SetColumn(nameof(StockDetail.Description), GetDescriptionsLength(paths));
	}

	private static List<int> GetIdsLength(List<StockDetail> models)
	{
		var rows = models.Select(e => GetId(e).Length).ToList();
		rows.Insert(0, nameof(StockDetail.Id).Length);
		return rows;
	}

	private static List<int> GetDescriptionsLength(List<StockDetail> models)
	{
		var rows = models.Select(e => GetDescription(e).Length).ToList();
		rows.Insert(0, nameof(StockDetail.Description).Length);
		return rows;
	}
}