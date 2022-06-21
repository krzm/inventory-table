using DataToTable;
using Inventory.Data;

namespace Inventory.Table;

public abstract class ImageColumn 
	: ImageText
{
    public ImageColumn(
		ITableTextEditor tableTextEditor
		, IColumnCalculator<Image> columnCalculator) 
			: base(tableTextEditor, columnCalculator)
    {
    }

    protected List<int> GetIdsLength(List<Image> m)
    {
        var rows = m.Select(e => GetId(e).Length).ToList();
		rows.Insert(0, nameof(Image.Id).Length);
		return rows;
    }

	protected List<int> GetItemsLength(List<Image> m)
    {
        var rows = m.Select(e => GetName(e).Length).ToList();
		rows.Insert(0, nameof(Image.Item).Length);
		return rows;
    }

	protected List<int> GetItemIdsLength(List<Image> m)
    {
        var rows = m.Select(e => GetItemId(e).Length).ToList();
		rows.Insert(0, nameof(Image.ItemId).Length);
		return rows;
    }

	protected List<int> GetPathsLength(List<Image> m)
    {
        var rows = m.Select(e => GetPath(e).Length).ToList();
		rows.Insert(0, nameof(Image.Path).Length);
		return rows;
    }
}