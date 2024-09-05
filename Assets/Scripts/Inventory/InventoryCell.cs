using System.Collections.Generic;
using Game.Items;


namespace Game.Inventory
{
    /// <summary>
    /// Ячейка в инвентаре
    /// </summary>
    [System.Serializable]
    public class InventoryCell
    {
        private int _idItem; // ID предмета
        public List<Item> _items; // предметы с данным ID

        public InventoryCell(int idItem, List<Item> items)
        {
            _idItem = idItem;
            _items = items;
        }

    }
}
