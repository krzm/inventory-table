using DataToTable;
using Inventory.Data;

namespace Inventory.Table;

public class CategoryTable 
    : CategoryColumn
{
	public CategoryTable(
		ITableTextEditor tableTextEditor
		, IColumnCalculator<Category> columnCalculator) 
			: base(tableTextEditor, columnCalculator)
    {
    }
		
	protected override void CreateTableHeader()
	{
		SetColumns();
	}

	private void SetColumns()
	{
		Editor.AddColumn(GetColumnData(nameof(Category.Id)));
        Editor.AddColumn(GetColumnData(nameof(Category.Name)));
        Editor.AddColumn(GetColumnData(nameof(Category.Description)));
		Editor.AddColumn(GetColumnData(nameof(Category.ParentId)));
		Editor.AddColumn(GetColumnData(nameof(Category.Parent)));
		Editor.AddColumn(GetColumnData("Related"));
	}

	protected override void CreateTableRow(Category m)
    {
        Editor.AddValue(GetColumnData(nameof(Category.Id)), GetId(m));
        Editor.AddValue(GetColumnData(nameof(Category.Name)), GetName(m));
        Editor.AddValue(GetColumnData(nameof(Category.Description)), GetDescription(m));
        Editor.AddValue(GetColumnData(nameof(Category.ParentId)), GetParentId(m));
        Editor.AddValue(GetColumnData(nameof(Category.Parent)), GetParent(m));
        Editor.AddValue(GetColumnData("Related"), GetChildren(m));
    }

    protected override void SetColumnsSize(List<Category> m)
	{
		SetColumn(nameof(Category.Id), GetIdsLength(m));
		SetColumn(nameof(Category.Name), GetNamesLength(m));
		SetColumn(nameof(Category.Description), GetDescriptionsLength(m));
		SetColumn(nameof(Category.ParentId), GetParentIdsLength(m));
		SetColumn(nameof(Category.Parent), GetParentsLength(m));
		SetColumn("Related", GetRelatedsLength(m));
	}
}