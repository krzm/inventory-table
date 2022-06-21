using DataToTable;
using Inventory.Data;

namespace Inventory.Table;

public class SizeTable
	: TextTable<Size>
{
    private const string Empty = "";

    public SizeTable(
		ITableTextEditor tableTextEditor
		, IColumnCalculator<Size> columnCalculator) 
			: base(tableTextEditor, columnCalculator)
    {
    }
		
	protected override void CreateTableHeader()
	{
		SetColumns();
	}

	private void SetColumns()
	{
		Editor.AddColumn(GetColumnData(nameof(Size.Id)));
        Editor.AddColumn(GetColumnData(nameof(Size.Description)));
		Editor.AddColumn(GetColumnData(nameof(Size.Length)));
		Editor.AddColumn(GetColumnData(nameof(Size.Depth)));
		Editor.AddColumn(GetColumnData(nameof(Size.Heigth)));
		Editor.AddColumn(GetColumnData(nameof(Size.Diameter)));
		Editor.AddColumn(GetColumnData(nameof(Size.Volume)));
	}

	protected override void CreateTableRow(Size e)
    {
        Editor.AddValue(GetColumnData(nameof(Size.Id)), GetId(e));
        Editor.AddValue(GetColumnData(nameof(Size.Description)), GetDescription(e));
        Editor.AddValue(GetColumnData(nameof(Size.Length)), GetLength(e));
		Editor.AddValue(GetColumnData(nameof(Size.Depth)), GetDepth(e));
		Editor.AddValue(GetColumnData(nameof(Size.Heigth)), GetHeigth(e));
		Editor.AddValue(GetColumnData(nameof(Size.Diameter)), GetDiameter(e));
		Editor.AddValue(GetColumnData(nameof(Size.Volume)), GetVolume(e));
	}

	private static string GetId(Size e) => e.Id.ToString();

	private static string GetDescription(Size e) => 
		string.IsNullOrWhiteSpace(e.Description) == false ? e.Description.ToString() : Empty;

	private static string GetLength(Size e) => e.Length.ToString();

	private static string GetDepth(Size e) => e.Depth.ToString();

	private static string GetHeigth(Size e) => e.Heigth.ToString();

	private static string GetDiameter(Size e) => e.Diameter.HasValue ? e.Diameter.Value.ToString() : Empty;

	private static string GetVolume(Size e) => e.Volume.HasValue ? e.Volume.Value.ToString() : Empty;

	protected override void SetColumnsSize(List<Size> paths)
	{
		SetColumn(nameof(Size.Id), GetIdLength(paths));
		SetColumn(nameof(Size.Description), GetDescriptionLength(paths));
		SetColumn(nameof(Size.Length), GetLengthLength(paths));
		SetColumn(nameof(Size.Depth), GetDepthLength(paths));
		SetColumn(nameof(Size.Heigth), GetHeigthLength(paths));
		SetColumn(nameof(Size.Diameter), GetDiameterLength(paths));
		SetColumn(nameof(Size.Volume), GetVolumeLength(paths));
	}

	private static List<int> GetIdLength(List<Size> models)
    {
        var rows = models.Select(e => GetId(e).Length).ToList();
		rows.Insert(0, nameof(Size.Id).Length);
		return rows;
    }

	private static List<int> GetDescriptionLength(List<Size> models)
    {
            var rows = models.Select(e => GetDescription(e).Length).ToList();
		rows.Insert(0, nameof(Size.Description).Length);
		return rows;
    }

	private static List<int> GetLengthLength(List<Size> models)
    {
        var rows = models.Select(e => GetLength(e).Length).ToList();
		rows.Insert(0, nameof(Size.Length).Length);
		return rows;
    }

	private static List<int> GetDepthLength(List<Size> models)
    {
        var rows = models.Select(e => GetDepth(e).Length).ToList();
		rows.Insert(0, nameof(Size.Depth).Length);
		return rows;
    }

	private static List<int> GetHeigthLength(List<Size> models)
	{
		var rows = models.Select(e => GetHeigth(e).Length).ToList();
		rows.Insert(0, nameof(Size.Heigth).Length);
		return rows;
	}

	private static List<int> GetDiameterLength(List<Size> models)
	{
		var rows = models.Select(e => GetDiameter(e).Length).ToList();
		rows.Insert(0, nameof(Size.Diameter).Length);
		return rows;
	}

	private static List<int> GetVolumeLength(List<Size> models)
	{
		var rows = models.Select(e => GetVolume(e).Length).ToList();
		rows.Insert(0, nameof(Size.Volume).Length);
		return rows;
	}
}