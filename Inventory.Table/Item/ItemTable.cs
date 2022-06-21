using DataToTable;
using Inventory.Data;

namespace Inventory.Table;

public class ItemTable 
	: ItemColumn
{
    private const string CategoryKey = "Category";
    private const string CategoryIdKey = "CategoryId";
    private const string DetailIdKey = "DetailId";

    public ItemTable(
		ITableTextEditor tableTextEditor
		, IColumnCalculator<Item> columnCalculator) 
			: base(tableTextEditor, columnCalculator)
    {
    }
		
	protected override void CreateTableHeader()
	{
		SetColumns();
	}

	private void SetColumns()
	{
		Editor.AddColumn(GetColumnData(nameof(Item.Id)));
		Editor.AddColumn(GetColumnData(nameof(Item.Name)));
		Editor.AddColumn(GetColumnData(CategoryKey));
		Editor.AddColumn(GetColumnData(CategoryIdKey));
		Editor.AddColumn(GetColumnData(DetailIdKey));
		Editor.AddColumn(GetColumnData(nameof(Item.Images)));
	}

	protected override void CreateTableRow(Item m)
	{
		Editor.AddValue(GetColumnData(nameof(Item.Id)), GetId(m));
		Editor.AddValue(GetColumnData(nameof(Item.Name)), GetName(m));
		Editor.AddValue(GetColumnData(CategoryKey), GetCategory(m));
		Editor.AddValue(GetColumnData(CategoryIdKey), GetCategoryId(m));
		Editor.AddValue(GetColumnData(DetailIdKey), GetDetailId(m));
		Editor.AddValue(GetColumnData(nameof(Item.Images)), GetImages(m));
	}

	protected override void SetColumnsSize(List<Item> m)
	{
		SetColumn(nameof(Item.Id), GetIdLength(m));
		SetColumn(nameof(Item.Name), GetNameLength(m));
		SetColumn(CategoryKey, GetCategoryLength(m));
		SetColumn(CategoryIdKey, GetCategoryIdLength(m));
		SetColumn(DetailIdKey, GetDetailIdLength(m));
		SetColumn(nameof(Item.Images), GetImagesLength(m));
	}
}