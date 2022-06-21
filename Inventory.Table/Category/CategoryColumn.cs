using DataToTable;
using Inventory.Data;

namespace Inventory.Table;

public abstract class CategoryColumn 
	: CategoryText
{
    public CategoryColumn(
		ITableTextEditor tableTextEditor
		, IColumnCalculator<Category> columnCalculator) 
			: base(tableTextEditor, columnCalculator)
    {
    }

    protected List<int> GetIdsLength(List<Category> models)
    {
        var rows = models.Select(m => GetId(m).Length).ToList();
		rows.Insert(0, nameof(Category.Id).Length);
		return rows;
    }

	protected List<int> GetNamesLength(List<Category> models)
    {
        var rows = models.Select(m => GetName(m).Length).ToList();
        rows.Insert(0, nameof(Category.Name).Length);
        return rows;
    }

	protected List<int> GetDescriptionsLength(List<Category> models)
    {
        var rows = models.Select(m => GetDescription(m).Length).ToList();
		rows.Insert(0, nameof(Category.Description).Length);
		return rows;
    }

	protected List<int> GetParentIdsLength(List<Category> models)
    {
        var rows = models.Select(e => GetParentId(e).Length).ToList();
		rows.Insert(0, nameof(Category.ParentId).Length);
		return rows;
    }

	protected List<int> GetParentsLength(List<Category> models)
    {
        var rows = models.Select(e => GetParent(e).Length).ToList();
		rows.Insert(0, nameof(Category.Parent).Length);
		return rows;
    }

	protected List<int> GetRelatedsLength(List<Category> models)
    {
        var rows = models.Select(e => GetChildren(e).Length).ToList();
		rows.Insert(0, "Related".Length);
		return rows;
    }
}