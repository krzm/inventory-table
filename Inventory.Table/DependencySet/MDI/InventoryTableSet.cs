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
            .AddSingleton<IColumnCalculator<ItemCategory>, ColumnCalculator<ItemCategory>>()
            .AddSingleton<IColumnCalculator<Item>, ColumnCalculator<Item>>()
            .AddSingleton<IColumnCalculator<ItemImage>, ColumnCalculator<ItemImage>>();
    }

    protected override void RegisterTableProviders()
    {
        Container
            .AddSingleton<ITableTextEditor, TableTextEditor>()
            .AddSingleton<IDataToText<ItemCategory>, ItemCategoryTable>()
            .AddSingleton<IDataToText<Item>, ItemTable>()
            .AddSingleton<IDataToText<ItemImage>, ItemImageTable>();
    }
}