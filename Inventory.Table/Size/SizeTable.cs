using DataToTable;
using Inventory.Data;

namespace Inventory.Table;

public class SizeTable
	: SizeColumn
{
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

	protected void SetColumns()
	{
		Editor.AddColumn(GetColumnData(nameof(Size.Id)));
        Editor.AddColumn(GetColumnData(nameof(Size.Description)));
		Editor.AddColumn(GetColumnData(nameof(Size.Length)));
		Editor.AddColumn(GetColumnData(nameof(Size.Depth)));
		Editor.AddColumn(GetColumnData(nameof(Size.Heigth)));
		Editor.AddColumn(GetColumnData(nameof(Size.Diameter)));
		Editor.AddColumn(GetColumnData(nameof(Size.Volume)));
	}

	protected override void CreateTableRow(Size m)
    {
        Editor.AddValue(GetColumnData(nameof(Size.Id)), GetId(m));
        Editor.AddValue(GetColumnData(nameof(Size.Description)), GetDescription(m));
        Editor.AddValue(GetColumnData(nameof(Size.Length)), GetLength(m));
		Editor.AddValue(GetColumnData(nameof(Size.Depth)), GetDepth(m));
		Editor.AddValue(GetColumnData(nameof(Size.Heigth)), GetHeigth(m));
		Editor.AddValue(GetColumnData(nameof(Size.Diameter)), GetDiameter(m));
		Editor.AddValue(GetColumnData(nameof(Size.Volume)), GetVolume(m));
	}

	protected override void SetColumnsSize(List<Size> m)
	{
		SetColumn(nameof(Size.Id), GetIdLength(m));
		SetColumn(nameof(Size.Description), GetDescriptionLength(m));
		SetColumn(nameof(Size.Length), GetLengthLength(m));
		SetColumn(nameof(Size.Depth), GetDepthLength(m));
		SetColumn(nameof(Size.Heigth), GetHeigthLength(m));
		SetColumn(nameof(Size.Diameter), GetDiameterLength(m));
		SetColumn(nameof(Size.Volume), GetVolumeLength(m));
	}
}