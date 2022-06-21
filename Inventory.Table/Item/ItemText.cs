using DataToTable;
using Inventory.Data;

namespace Inventory.Table;

public abstract class ItemText
	: TextTable<Item>
{
    private const string Empty = "";

    public ItemText(
		ITableTextEditor tableTextEditor
		, IColumnCalculator<Item> columnCalculator) 
			: base(tableTextEditor, columnCalculator)
    {
    }

    protected string GetId(Item m) => m.Id.ToString();

	protected string GetName(Item m)
    {
        ArgumentNullException.ThrowIfNull(m.Name);
        return m.Name;
    }

    protected string GetCategory(Item m) => 
		m.Category != null ? 
			(string.IsNullOrWhiteSpace(m.Category.Name) ? Empty : m.Category.Name)
			: Empty;

	protected string GetCategoryId(Item m) => m.CategoryId.ToString();

	protected string GetDetailId(Item m) => m.SizeId.HasValue ? m.SizeId.Value.ToString() : Empty;

	protected string GetImages(Item m) => m.Images != null ? m.Images.Count.ToString() : Empty;
}
