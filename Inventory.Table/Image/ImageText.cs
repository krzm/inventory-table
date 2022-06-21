using DataToTable;
using Inventory.Data;

namespace Inventory.Table;

public abstract class ImageText
	: TextTable<Image>
{
    public ImageText(
		ITableTextEditor tableTextEditor
		, IColumnCalculator<Image> columnCalculator) 
			: base(tableTextEditor, columnCalculator)
    {
    }

    protected string GetId(Image m) =>
        m.Id.ToString();

    protected string GetName(Image m)
    {
        var item = m.Item;
        ArgumentNullException.ThrowIfNull(item);
        ArgumentNullException.ThrowIfNull(item.Name);
        return item.Name;
    }

    protected string GetItemId(Image m)
    {
        var item = m.Item;
        ArgumentNullException.ThrowIfNull(item);
        return item.Id.ToString();
    }

    protected string GetPath(Image m)
    {
        ArgumentNullException.ThrowIfNull(m.Path);
        return m.Path;
    }
}
