using DataToTable;
using Inventory.Data;

namespace Inventory.Table;

public abstract class ItemColumn
	: ItemText
{
    public ItemColumn(
		ITableTextEditor tableTextEditor
		, IColumnCalculator<Item> columnCalculator) 
			: base(tableTextEditor, columnCalculator)
    {
    }

    protected List<int> GetIdLength(List<Item> m)
    {
        var rows = m.Select(e => GetId(e).Length).ToList();
		rows.Insert(0, nameof(Item.Id).Length);
		return rows;
    }

	protected List<int> GetNameLength(List<Item> m)
    {
            var rows = m.Select(e => GetName(e).Length).ToList();
		rows.Insert(0, nameof(Item.Name).Length);
		return rows;
    }

	protected List<int> GetCategoryLength(List<Item> m)
	{
		var rows = m.Select(e => GetCategory(e).Length).ToList();
		rows.Insert(0, nameof(Item.Category).Length);
		return rows;
	}

	protected List<int> GetCategoryIdLength(List<Item> m)
	{
		var rows = m.Select(e => GetCategoryId(e).Length).ToList();
		rows.Insert(0, nameof(Item.CategoryId).Length);
		return rows;
	}

	protected List<int> GetDetailIdLength(List<Item> m)
	{
		var rows = m.Select(e => GetDetailId(e).Length).ToList();
		rows.Insert(0, nameof(Item.SizeId).Length);
		return rows;
	}

	protected List<int> GetImagesLength(List<Item> m)
	{
		var rows = m.Select(e => GetImages(e).Length).ToList();
		rows.Insert(0, nameof(Item.Images).Length);
		return rows;
	}
}
