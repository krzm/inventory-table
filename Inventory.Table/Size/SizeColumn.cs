using DataToTable;
using Inventory.Data;

namespace Inventory.Table;

public abstract class SizeColumn
	: SizeText
{
    public SizeColumn(
		ITableTextEditor tableTextEditor
		, IColumnCalculator<Size> columnCalculator) 
			: base(tableTextEditor, columnCalculator)
    {
    }

    protected List<int> GetIdLength(List<Size> m)
    {
        var rows = m.Select(e => GetId(e).Length).ToList();
		rows.Insert(0, nameof(Size.Id).Length);
		return rows;
    }

	protected List<int> GetDescriptionLength(List<Size> m)
    {
            var rows = m.Select(e => GetDescription(e).Length).ToList();
		rows.Insert(0, nameof(Size.Description).Length);
		return rows;
    }

	protected List<int> GetLengthLength(List<Size> m)
    {
        var rows = m.Select(e => GetLength(e).Length).ToList();
		rows.Insert(0, nameof(Size.Length).Length);
		return rows;
    }

	protected List<int> GetDepthLength(List<Size> m)
    {
        var rows = m.Select(e => GetDepth(e).Length).ToList();
		rows.Insert(0, nameof(Size.Depth).Length);
		return rows;
    }

	protected List<int> GetHeigthLength(List<Size> m)
	{
		var rows = m.Select(e => GetHeigth(e).Length).ToList();
		rows.Insert(0, nameof(Size.Heigth).Length);
		return rows;
	}

	protected List<int> GetDiameterLength(List<Size> m)
	{
		var rows = m.Select(e => GetDiameter(e).Length).ToList();
		rows.Insert(0, nameof(Size.Diameter).Length);
		return rows;
	}

	protected List<int> GetVolumeLength(List<Size> m)
	{
		var rows = m.Select(e => GetVolume(e).Length).ToList();
		rows.Insert(0, nameof(Size.Volume).Length);
		return rows;
	}
}
