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
            .RegisterType<IColumnCalculator<ItemCategory>, ColumnCalculator<ItemCategory>>()
            .RegisterType<IColumnCalculator<ItemDetail>, ColumnCalculator<ItemDetail>>()
            .RegisterType<IColumnCalculator<ItemImage>, ColumnCalculator<ItemImage>>()
            .RegisterType<IColumnCalculator<Stock>, ColumnCalculator<Stock>>()
            .RegisterType<IColumnCalculator<StockDetail>, ColumnCalculator<StockDetail>>();
    }

    protected override void RegisterTableProviders()
    {
        Container
            .RegisterType<IDataToText<Item>, ItemTable>()
            .RegisterType<IDataToText<ItemCategory>, ItemCategoryTable>()
            .RegisterType<IDataToText<ItemDetail>, ItemDetailTable>()
            .RegisterType<IDataToText<ItemImage>, ItemImageTable>()
            .RegisterType<IDataToText<Stock>, StockTable>()
            .RegisterType<IDataToText<StockDetail>, StockDetailTable>();
    }
}