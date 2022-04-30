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
            .AddSingleton<IColumnCalculator<Category>, ColumnCalculator<Category>>()
            .AddSingleton<IColumnCalculator<Size>, ColumnCalculator<Size>>()
            .AddSingleton<IColumnCalculator<Image>, ColumnCalculator<Image>>()
            .AddSingleton<IColumnCalculator<Stock>, ColumnCalculator<Stock>>();
    }

    protected override void RegisterTableProviders()
    {
        Container
            .AddSingleton<IDataToText<Item>, ItemTable>()
            .AddSingleton<IDataToText<Category>, CategoryTable>()
            .AddSingleton<IDataToText<Size>, SizeTable>()
            .AddSingleton<IDataToText<Image>, ImageTable>()
            .AddSingleton<IDataToText<Stock>, StockTable>();
    }
}