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
            .RegisterType<IColumnCalculator<ItemCategory>, ColumnCalculator<ItemCategory>>()
            .RegisterType<IColumnCalculator<Item>, ColumnCalculator<Item>>()
            .RegisterType<IColumnCalculator<ItemImage>, ColumnCalculator<ItemImage>>();
    }

    protected override void RegisterTableProviders()
    {
         Container
            .RegisterType<ITableTextEditor, TableTextEditor>()
            .RegisterType<IDataToText<ItemCategory>, ItemCategoryTable>()
	        .RegisterType<IDataToText<Item>, ItemTable>()
	        .RegisterType<IDataToText<ItemImage>, ItemImageTable>();
    }
}