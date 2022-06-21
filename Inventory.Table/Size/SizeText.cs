using DataToTable;
using Inventory.Data;

namespace Inventory.Table;

public abstract class SizeText
	: TextTable<Size>
{
    private const string Empty = "";

    public SizeText(
		ITableTextEditor tableTextEditor
		, IColumnCalculator<Size> columnCalculator) 
			: base(tableTextEditor, columnCalculator)
    {
    }

    protected string GetId(Size m) => m.Id.ToString();

	protected string GetDescription(Size m) => 
		string.IsNullOrWhiteSpace(m.Description) == false ? m.Description.ToString() : Empty;

	protected string GetLength(Size m)
    {
        return m.Length.HasValue ? m.Length.Value.ToString() : Empty;
    }

    protected string GetDepth(Size m)
    {
        return m.Depth.HasValue ? m.Depth.Value.ToString() : Empty;
    }

    protected string GetHeigth(Size m)
    {
        return m.Heigth.HasValue ? m.Heigth.Value.ToString() : Empty;
    }

    protected string GetDiameter(Size m) => m.Diameter.HasValue ? m.Diameter.Value.ToString() : Empty;

	protected string GetVolume(Size m) => m.Volume.HasValue ? m.Volume.Value.ToString() : Empty;
}
