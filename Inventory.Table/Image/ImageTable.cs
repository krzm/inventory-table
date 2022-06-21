using DataToTable;
using Inventory.Data;

namespace Inventory.Table;

public class ImageTable 
	: TextTable<Image>
{
	public ImageTable(
		ITableTextEditor tableTextEditor
		, IColumnCalculator<Image> columnCalculator) 
			: base(tableTextEditor, columnCalculator)
    {
    }
		
	protected override void CreateTableHeader()
	{
		SetColumns();
	}

	private void SetColumns()
	{
		Editor.AddColumn(GetColumnData(nameof(Image.Id)));
        Editor.AddColumn(GetColumnData(nameof(Image.Item)));
        Editor.AddColumn(GetColumnData(nameof(Image.ItemId)));
		Editor.AddColumn(GetColumnData(nameof(Image.Path)));
	}

	protected override void CreateTableRow(Image e)
	{
		Editor.AddValue(GetColumnData(nameof(Image.Id)), e.Id.ToString());
		Editor.AddValue(GetColumnData(nameof(Image.Item)), e.Item.Name);
		Editor.AddValue(GetColumnData(nameof(Image.ItemId)), e.ItemId.ToString());
		Editor.AddValue(GetColumnData(nameof(Image.Path)), e.Path);		
    }

	protected override void SetColumnsSize(List<Image> paths)
	{
		SetColumn(nameof(Image.Id), GetIdsLength(paths));
		SetColumn(nameof(Image.Item), GetItemsLength(paths));
		SetColumn(nameof(Image.ItemId), GetItemIdsLength(paths));
		SetColumn(nameof(Image.Path), GetPathsLength(paths));
	}

	private static List<int> GetIdsLength(List<Image> models)
    {
        var rows = models.Select(e => e.Id.ToString().Length).ToList();
		rows.Insert(0, nameof(Image.Id).Length);
		return rows;
    }

	private static List<int> GetItemsLength(List<Image> models)
    {
            var rows = models.Select(e => e.Item.Name.Length).ToList();
		rows.Insert(0, nameof(Image.Item).Length);
		return rows;
    }

	private static List<int> GetItemIdsLength(List<Image> models)
    {
            var rows = models.Select(e => e.ItemId.ToString().Length).ToList();
		rows.Insert(0, nameof(Image.ItemId).Length);
		return rows;
    }

	private static List<int> GetPathsLength(List<Image> models)
    {
        var rows = models.Select(e => e.Path.Length).ToList();
		rows.Insert(0, nameof(Image.Path).Length);
		return rows;
    }
}