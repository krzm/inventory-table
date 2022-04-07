using DataToTable;
using Inventory.Data;

namespace Inventory.Table;

public class ItemCategoryTable 
	: TextTable<ItemCategory>
{
	public ItemCategoryTable(
		ITableTextEditor tableTextEditor
		, IColumnCalculator<ItemCategory> columnCalculator) 
			: base(tableTextEditor, columnCalculator)
    {
    }
		
	protected override void CreateTableHeader()
	{
		SetColumns();
	}

	private void SetColumns()
	{
		Editor.AddColumn(GetColumnData(nameof(ItemCategory.Id)));
        Editor.AddColumn(GetColumnData(nameof(ItemCategory.Name)));
        Editor.AddColumn(GetColumnData(nameof(ItemCategory.Description)));
		Editor.AddColumn(GetColumnData(nameof(ItemCategory.ParentId)));
		Editor.AddColumn(GetColumnData(nameof(ItemCategory.Parent)));
		Editor.AddColumn(GetColumnData("Related"));
	}

	protected override void CreateTableRow(ItemCategory e)
    {
        Editor.AddValue(GetColumnData(nameof(ItemCategory.Id)), GetId(e));
        Editor.AddValue(GetColumnData(nameof(ItemCategory.Name)), e.Name);
        Editor.AddValue(GetColumnData(nameof(ItemCategory.Description)), e.Description);
        Editor.AddValue(GetColumnData(nameof(ItemCategory.ParentId)), GetParentId(e));
        Editor.AddValue(GetColumnData(nameof(ItemCategory.Parent)), GetParent(e));
        Editor.AddValue(GetColumnData("Related"), GetChildren(e));
    }

    private static string GetId(ItemCategory e) => e.Id.ToString();

    private static string GetParentId(ItemCategory e) => e.ParentId.HasValue ? e.ParentId.Value.ToString() : "";

    private static string GetParent(ItemCategory e) => e.ParentId.HasValue ? e.Parent.Name : "";

    private static string GetChildren(ItemCategory e) => e.Children.Any() ? string.Join(",", e.Children.Select(c => c.Name)) : "";

    protected override void SetColumnsSize(List<ItemCategory> paths)
	{
		SetColumn(nameof(ItemCategory.Id), GetIdsLength(paths));
		SetColumn(nameof(ItemCategory.Name), GetNamesLength(paths));
		SetColumn(nameof(ItemCategory.Description), GetDescriptionsLength(paths));
		SetColumn(nameof(ItemCategory.ParentId), GetParentIdsLength(paths));
		SetColumn(nameof(ItemCategory.Parent), GetParentsLength(paths));
		SetColumn("Related", GetRelatedsLength(paths));
	}

	private static List<int> GetIdsLength(List<ItemCategory> models)
    {
        var rows = models.Select(e => GetId(e).Length).ToList();
		rows.Insert(0, nameof(ItemCategory.Id).Length);
		return rows;
    }

	private static List<int> GetNamesLength(List<ItemCategory> models)
    {
            var rows = models.Select(e => e.Name.Length).ToList();
		rows.Insert(0, nameof(ItemCategory.Name).Length);
		return rows;
    }

	private static List<int> GetDescriptionsLength(List<ItemCategory> models)
    {
            var rows = models.Select(e => e.Description.Length).ToList();
		rows.Insert(0, nameof(ItemCategory.Description).Length);
		return rows;
    }

	private static List<int> GetParentIdsLength(List<ItemCategory> models)
    {
        var rows = models.Select(e => GetParentId(e).Length).ToList();
		rows.Insert(0, nameof(ItemCategory.ParentId).Length);
		return rows;
    }

	private static List<int> GetParentsLength(List<ItemCategory> models)
    {
        var rows = models.Select(e => GetParent(e).Length).ToList();
		rows.Insert(0, nameof(ItemCategory.Parent).Length);
		return rows;
    }

	private static List<int> GetRelatedsLength(List<ItemCategory> models)
    {
        var rows = models.Select(e => GetChildren(e).Length).ToList();
		rows.Insert(0, "Related".Length);
		return rows;
    }
}