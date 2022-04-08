using DataToTable;
using DataToTable.MDI;
using Inventory.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory.Table.MDI;

public class InventoryTableSet 
    : DataToTableSet
{
    public InventoryTableSet(
        IServiceCollection container) 
            : base(container)
    {
    }

    protected override void RegisterColumnCalculators()
    {
        Container
            .AddSingleton<IColumnCalculator<Item>, ColumnCalculator<Item>>()
            .AddSingleton<IColumnCalculator<ItemCategory>, ColumnCalculator<ItemCategory>>()
            .AddSingleton<IColumnCalculator<ItemDetail>, ColumnCalculator<ItemDetail>>()
            .AddSingleton<IColumnCalculator<ItemImage>, ColumnCalculator<ItemImage>>()
            .AddSingleton<IColumnCalculator<Stock>, ColumnCalculator<Stock>>()
            .AddSingleton<IColumnCalculator<StockDetail>, ColumnCalculator<StockDetail>>();
    }

    protected override void RegisterTableProviders()
    {
        Container
            .AddSingleton<IDataToText<Item>, ItemTable>()
            .AddSingleton<IDataToText<ItemCategory>, ItemCategoryTable>()
            .AddSingleton<IDataToText<ItemDetail>, ItemDetailTable>()
            .AddSingleton<IDataToText<ItemImage>, ItemImageTable>()
            .AddSingleton<IDataToText<Stock>, StockTable>()
            .AddSingleton<IDataToText<StockDetail>, StockDetailTable>();
    }
}