using DataToTable;
using Inventory.Data;

namespace Inventory.Table;

public class ItemTable 
	: TextTable<Item>
{
    private const string Empty = "";
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

	protected override void CreateTableRow(Item e)
	{
		Editor.AddValue(GetColumnData(nameof(Item.Id)), GetId(e));
		Editor.AddValue(GetColumnData(nameof(Item.Name)), GetName(e));
		Editor.AddValue(GetColumnData(CategoryKey), GetCategory(e));
		Editor.AddValue(GetColumnData(CategoryIdKey), GetCategoryId(e));
		Editor.AddValue(GetColumnData(DetailIdKey), GetDetailId(e));
		Editor.AddValue(GetColumnData(nameof(Item.Images)), GetImages(e));
	}

	private static string GetId(Item e) => e.Id.ToString();

	private static string GetName(Item e) => e.Name;

	private static string GetCategory(Item e) => e.ItemCategory.Name;

	private static string GetCategoryId(Item e) => e.ItemCategoryId.ToString();

	private static string GetDetailId(Item e) => e.ItemDetailId.HasValue ? e.ItemDetailId.Value.ToString() : Empty;

	private static string GetImages(Item e) => e.Images != null ? e.Images.Count.ToString() : Empty;

	protected override void SetColumnsSize(List<Item> items)
	{
		SetColumn(nameof(Item.Id), GetIdLength(items));
		SetColumn(nameof(Item.Name), GetNameLength(items));
		SetColumn(CategoryKey, GetCategoryLength(items));
		SetColumn(CategoryIdKey, GetCategoryIdLength(items));
		SetColumn(DetailIdKey, GetDetailIdLength(items));
		SetColumn(nameof(Item.Images), GetImagesLength(items));
	}

	private static List<int> GetIdLength(List<Item> models)
    {
        var rows = models.Select(e => GetId(e).Length).ToList();
		rows.Insert(0, nameof(Item.Id).Length);
		return rows;
    }

	private static List<int> GetNameLength(List<Item> items)
    {
            var rows = items.Select(e => GetName(e).Length).ToList();
		rows.Insert(0, nameof(Item.Name).Length);
		return rows;
    }

	private static List<int> GetCategoryLength(List<Item> items)
	{
		var rows = items.Select(e => GetCategory(e).Length).ToList();
		rows.Insert(0, nameof(Item.ItemCategory).Length);
		return rows;
	}

	private static List<int> GetCategoryIdLength(List<Item> items)
	{
		var rows = items.Select(e => GetCategoryId(e).Length).ToList();
		rows.Insert(0, nameof(Item.ItemCategoryId).Length);
		return rows;
	}

	private static List<int> GetDetailIdLength(List<Item> items)
	{
		var rows = items.Select(e => GetDetailId(e).Length).ToList();
		rows.Insert(0, nameof(Item.ItemDetailId).Length);
		return rows;
	}

	private static List<int> GetImagesLength(List<Item> items)
	{
		var rows = items.Select(e => GetImages(e).Length).ToList();
		rows.Insert(0, nameof(Item.Images).Length);
		return rows;
	}
}