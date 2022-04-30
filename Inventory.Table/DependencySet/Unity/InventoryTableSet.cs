using DataToTable;
using DataToTable.Unity;
using Inventory.Data;
using Unity;

namespace Inventory.Table.Unity;

public class InventoryTableSet 
    : DataToTableSet
{
    public InventoryTableSet(
        IUnityContainer container) 
        : base(container)
    {
    }

    protected override void RegisterColumnCalculators()
    {
        Container
            .RegisterType<IColumnCalculator<Item>, ColumnCalculator<Item>>()
            .RegisterType<IColumnCalculator<Category>, ColumnCalculator<Category>>()
            .RegisterType<IColumnCalculator<Size>, ColumnCalculator<Size>>()
            .RegisterType<IColumnCalculator<Image>, ColumnCalculator<Image>>()
            .RegisterType<IColumnCalculator<Stock>, ColumnCalculator<Stock>>();
    }

    protected override void RegisterTableProviders()
    {
        Container
            .RegisterType<ITableTextEditor, TableTextEditor>()
            .RegisterType<IDataToText<Item>, ItemTable>()
            .RegisterType<IDataToText<Category>, CategoryTable>()
            .RegisterType<IDataToText<Size>, SizeTable>()
            .RegisterType<IDataToText<Image>, ImageTable>()
            .RegisterType<IDataToText<Stock>, StockTable>();
    }
}