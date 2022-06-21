using DataToTable;
using Inventory.Data;

namespace Inventory.Table;

public abstract class CategoryText 
	: TextTable<Category>
{
    public CategoryText(
		ITableTextEditor tableTextEditor
		, IColumnCalculator<Category> columnCalculator) 
			: base(tableTextEditor, columnCalculator)
    {
    }

    protected string GetId(Category m) =>
        m.Id.ToString();

    protected string GetName(Category m) =>
        string.IsNullOrWhiteSpace(m.Name) == false ? m.Name : string.Empty;

    protected string GetDescription(Category m) =>
        string.IsNullOrWhiteSpace(m.Description) == false ? m.Description : string.Empty;

    protected string GetParentId(Category m) =>
        m.ParentId.HasValue ? m.ParentId.Value.ToString() : string.Empty;

    protected string GetParent(Category m)
    {
        ArgumentNullException.ThrowIfNull(m.Parent);
        return string.IsNullOrWhiteSpace(m.Parent.Name) == false ? m.Parent.Name : string.Empty;
    }
       
    protected string GetChildren(Category m)
    {
        ArgumentNullException.ThrowIfNull(m.Children);
        return m.Children.Any() ? string.Join(",", m.Children.Select(c => c.Name)) : string.Empty;   
    }
}