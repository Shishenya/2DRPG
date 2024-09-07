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

        public int IdItem { get => _idItem; }

        public int CountItems => _items.Count;

        public InventoryCell(int idItem, List<Item> items)
        {
            _idItem = idItem;
            _items = items;
        }

        /// <summary>
        /// Добавление предмета
        /// </summary>
        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            _items.Remove(item);
            if (CountItems == 0) _idItem = -1;
        }

    }
}
