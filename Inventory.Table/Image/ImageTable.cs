using DataToTable;
using Inventory.Data;

namespace Inventory.Table;

public class ImageTable 
	: ImageColumn
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

	protected void SetColumns()
	{
		Editor.AddColumn(GetColumnData(nameof(Image.Id)));
        Editor.AddColumn(GetColumnData(nameof(Image.Item)));
        Editor.AddColumn(GetColumnData(nameof(Image.ItemId)));
		Editor.AddColumn(GetColumnData(nameof(Image.Path)));
	}

	protected override void CreateTableRow(Image m)
	{
		Editor.AddValue(GetColumnData(nameof(Image.Id)), GetId(m));
		Editor.AddValue(GetColumnData(nameof(Image.Item)), GetName(m));
		Editor.AddValue(GetColumnData(nameof(Image.ItemId)), GetItemId(m));
		Editor.AddValue(GetColumnData(nameof(Image.Path)), GetPath(m));		
    }

	protected override void SetColumnsSize(List<Image> m)
	{
		SetColumn(nameof(Image.Id), GetIdsLength(m));
		SetColumn(nameof(Image.Item), GetItemsLength(m));
		SetColumn(nameof(Image.ItemId), GetItemIdsLength(m));
		SetColumn(nameof(Image.Path), GetPathsLength(m));
	}
}