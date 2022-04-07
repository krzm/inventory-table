using DataToTable;
using Inventory.Data;

namespace Inventory.Table;

public class ItemDetailTable
	: TextTable<ItemDetail>
{
    private const string Empty = "";

    public ItemDetailTable(
		ITableTextEditor tableTextEditor
		, IColumnCalculator<ItemDetail> columnCalculator) 
			: base(tableTextEditor, columnCalculator)
    {
    }
		
	protected override void CreateTableHeader()
	{
		SetColumns();
	}

	private void SetColumns()
	{
		Editor.AddColumn(GetColumnData(nameof(ItemDetail.Id)));
        Editor.AddColumn(GetColumnData(nameof(ItemDetail.Description)));
		Editor.AddColumn(GetColumnData(nameof(ItemDetail.Width)));
		Editor.AddColumn(GetColumnData(nameof(ItemDetail.Depth)));
		Editor.AddColumn(GetColumnData(nameof(ItemDetail.Heigth)));
		Editor.AddColumn(GetColumnData(nameof(ItemDetail.Diameter)));
		Editor.AddColumn(GetColumnData(nameof(ItemDetail.Volume)));
	}

	protected override void CreateTableRow(ItemDetail e)
    {
        Editor.AddValue(GetColumnData(nameof(ItemDetail.Id)), GetId(e));
        Editor.AddValue(GetColumnData(nameof(ItemDetail.Description)), GetDescription(e));
        Editor.AddValue(GetColumnData(nameof(ItemDetail.Width)), GetWidth(e));
		Editor.AddValue(GetColumnData(nameof(ItemDetail.Depth)), GetDepth(e));
		Editor.AddValue(GetColumnData(nameof(ItemDetail.Heigth)), GetHeigth(e));
		Editor.AddValue(GetColumnData(nameof(ItemDetail.Diameter)), GetDiameter(e));
		Editor.AddValue(GetColumnData(nameof(ItemDetail.Volume)), GetVolume(e));
	}

	private static string GetId(ItemDetail e) => e.Id.ToString();

	private static string GetDescription(ItemDetail e) => 
		string.IsNullOrWhiteSpace(e.Description) == false ? e.Description.ToString() : Empty;

	private static string GetWidth(ItemDetail e) => e.Width.HasValue ? e.Width.Value.ToString() : Empty;

	private static string GetDepth(ItemDetail e) => e.Depth.HasValue ? e.Depth.Value.ToString() : Empty;

	private static string GetHeigth(ItemDetail e) => e.Heigth.HasValue ? e.Heigth.Value.ToString() : Empty;

	private static string GetDiameter(ItemDetail e) => e.Diameter.HasValue ? e.Diameter.Value.ToString() : Empty;

	private static string GetVolume(ItemDetail e) => e.Volume.HasValue ? e.Volume.Value.ToString() : Empty;

	protected override void SetColumnsSize(List<ItemDetail> paths)
	{
		SetColumn(nameof(ItemDetail.Id), GetIdLength(paths));
		SetColumn(nameof(ItemDetail.Description), GetDescriptionLength(paths));
		SetColumn(nameof(ItemDetail.Width), GetWidthLength(paths));
		SetColumn(nameof(ItemDetail.Depth), GetDepthLength(paths));
		SetColumn(nameof(ItemDetail.Heigth), GetHeigthLength(paths));
		SetColumn(nameof(ItemDetail.Diameter), GetDiameterLength(paths));
		SetColumn(nameof(ItemDetail.Volume), GetVolumeLength(paths));
	}

	private static List<int> GetIdLength(List<ItemDetail> models)
    {
        var rows = models.Select(e => GetId(e).Length).ToList();
		rows.Insert(0, nameof(ItemDetail.Id).Length);
		return rows;
    }

	private static List<int> GetDescriptionLength(List<ItemDetail> models)
    {
            var rows = models.Select(e => GetDescription(e).Length).ToList();
		rows.Insert(0, nameof(ItemDetail.Description).Length);
		return rows;
    }

	private static List<int> GetWidthLength(List<ItemDetail> models)
    {
        var rows = models.Select(e => GetWidth(e).Length).ToList();
		rows.Insert(0, nameof(ItemDetail.Width).Length);
		return rows;
    }

	private static List<int> GetDepthLength(List<ItemDetail> models)
    {
        var rows = models.Select(e => GetDepth(e).Length).ToList();
		rows.Insert(0, nameof(ItemDetail.Depth).Length);
		return rows;
    }

	private static List<int> GetHeigthLength(List<ItemDetail> models)
	{
		var rows = models.Select(e => GetHeigth(e).Length).ToList();
		rows.Insert(0, nameof(ItemDetail.Heigth).Length);
		return rows;
	}

	private static List<int> GetDiameterLength(List<ItemDetail> models)
	{
		var rows = models.Select(e => GetDiameter(e).Length).ToList();
		rows.Insert(0, nameof(ItemDetail.Diameter).Length);
		return rows;
	}

	private static List<int> GetVolumeLength(List<ItemDetail> models)
	{
		var rows = models.Select(e => GetVolume(e).Length).ToList();
		rows.Insert(0, nameof(ItemDetail.Volume).Length);
		return rows;
	}
}