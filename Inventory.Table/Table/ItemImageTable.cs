using DataToTable;
using Inventory.Data;

namespace Inventory.Table;

public class ItemImageTable 
	: TextTable<ItemImage>
{
	public ItemImageTable(
		ITableTextEditor tableTextEditor
		, IColumnCalculator<ItemImage> columnCalculator) 
			: base(tableTextEditor, columnCalculator)
    {
    }
		
	protected override void CreateTableHeader()
	{
		SetColumns();
	}

	private void SetColumns()
	{
		Editor.AddColumn(GetColumnData(nameof(ItemImage.Id)));
        Editor.AddColumn(GetColumnData(nameof(ItemImage.Item)));
        Editor.AddColumn(GetColumnData(nameof(ItemImage.ItemId)));
		Editor.AddColumn(GetColumnData(nameof(ItemImage.Path)));
	}

	protected override void CreateTableRow(ItemImage e)
	{
		Editor.AddValue(GetColumnData(nameof(ItemImage.Id)), e.Id.ToString());
		Editor.AddValue(GetColumnData(nameof(ItemImage.Item)), e.Item.Name);
		Editor.AddValue(GetColumnData(nameof(ItemImage.ItemId)), e.ItemId.ToString());
		Editor.AddValue(GetColumnData(nameof(ItemImage.Path)), e.Path);		
    }

	protected override void SetColumnsSize(List<ItemImage> paths)
	{
		SetColumn(nameof(ItemImage.Id), GetIdsLength(paths));
		SetColumn(nameof(ItemImage.Item), GetItemsLength(paths));
		SetColumn(nameof(ItemImage.ItemId), GetItemIdsLength(paths));
		SetColumn(nameof(ItemImage.Path), GetPathsLength(paths));
	}

	private static List<int> GetIdsLength(List<ItemImage> models)
    {
        var rows = models.Select(e => e.Id.ToString().Length).ToList();
		rows.Insert(0, nameof(ItemImage.Id).Length);
		return rows;
    }

	private static List<int> GetItemsLength(List<ItemImage> models)
    {
            var rows = models.Select(e => e.Item.Name.Length).ToList();
		rows.Insert(0, nameof(ItemImage.Item).Length);
		return rows;
    }

	private static List<int> GetItemIdsLength(List<ItemImage> models)
    {
            var rows = models.Select(e => e.ItemId.ToString().Length).ToList();
		rows.Insert(0, nameof(ItemImage.ItemId).Length);
		return rows;
    }

	private static List<int> GetPathsLength(List<ItemImage> models)
    {
        var rows = models.Select(e => e.Path.Length).ToList();
		rows.Insert(0, nameof(ItemImage.Path).Length);
		return rows;
    }
}