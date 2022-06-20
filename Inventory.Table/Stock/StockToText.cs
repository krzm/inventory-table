using DataToTable;
using Inventory.Data;

namespace Inventory.Table;

public abstract class StockToText
    : TextTable<Stock>
{
    public StockToText(
		ITableTextEditor tableTextEditor
		, IColumnCalculator<Stock> columnCalculator)
			: base(tableTextEditor, columnCalculator)
	{
	}

    protected string GetId(Stock m) =>
        m.Id.ToString();

	protected string GetItem(Stock m)
    {
        ArgumentNullException.ThrowIfNull(m.Item);
        return string.IsNullOrWhiteSpace(m.Item.Name) == false ?
            m.Item.Name
            : string.Empty;
    }
       
	protected string GetItemId(Stock m) =>
        m.ItemId.ToString();
}