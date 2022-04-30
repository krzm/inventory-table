using DataToTable;
using Inventory.Data;

namespace Inventory.Table;

public class CategoryTable 
	: TextTable<Category>
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

	protected override void CreateTableRow(Category e)
    {
        Editor.AddValue(GetColumnData(nameof(Category.Id)), GetId(e));
        Editor.AddValue(GetColumnData(nameof(Category.Name)), e.Name);
        Editor.AddValue(GetColumnData(nameof(Category.Description)), e.Description);
        Editor.AddValue(GetColumnData(nameof(Category.ParentId)), GetParentId(e));
        Editor.AddValue(GetColumnData(nameof(Category.Parent)), GetParent(e));
        Editor.AddValue(GetColumnData("Related"), GetChildren(e));
    }

    private static string GetId(Category e) => e.Id.ToString();

    private static string GetParentId(Category e) => e.ParentId.HasValue ? e.ParentId.Value.ToString() : "";

    private static string GetParent(Category e) => e.ParentId.HasValue ? e.Parent.Name : "";

    private static string GetChildren(Category e) => e.Children.Any() ? string.Join(",", e.Children.Select(c => c.Name)) : "";

    protected override void SetColumnsSize(List<Category> paths)
	{
		SetColumn(nameof(Category.Id), GetIdsLength(paths));
		SetColumn(nameof(Category.Name), GetNamesLength(paths));
		SetColumn(nameof(Category.Description), GetDescriptionsLength(paths));
		SetColumn(nameof(Category.ParentId), GetParentIdsLength(paths));
		SetColumn(nameof(Category.Parent), GetParentsLength(paths));
		SetColumn("Related", GetRelatedsLength(paths));
	}

	private static List<int> GetIdsLength(List<Category> models)
    {
        var rows = models.Select(e => GetId(e).Length).ToList();
		rows.Insert(0, nameof(Category.Id).Length);
		return rows;
    }

	private static List<int> GetNamesLength(List<Category> models)
    {
            var rows = models.Select(e => e.Name.Length).ToList();
		rows.Insert(0, nameof(Category.Name).Length);
		return rows;
    }

	private static List<int> GetDescriptionsLength(List<Category> models)
    {
            var rows = models.Select(e => e.Description.Length).ToList();
		rows.Insert(0, nameof(Category.Description).Length);
		return rows;
    }

	private static List<int> GetParentIdsLength(List<Category> models)
    {
        var rows = models.Select(e => GetParentId(e).Length).ToList();
		rows.Insert(0, nameof(Category.ParentId).Length);
		return rows;
    }

	private static List<int> GetParentsLength(List<Category> models)
    {
        var rows = models.Select(e => GetParent(e).Length).ToList();
		rows.Insert(0, nameof(Category.Parent).Length);
		return rows;
    }

	private static List<int> GetRelatedsLength(List<Category> models)
    {
        var rows = models.Select(e => GetChildren(e).Length).ToList();
		rows.Insert(0, "Related".Length);
		return rows;
    }
}