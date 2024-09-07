using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Game.Items;

namespace Game.Inventory
{

    /// <summary>
    /// »нвентарь существа
    /// </summary>
    public class CreatureInventory : MonoBehaviour
    {
        [Tooltip("ћаксимальное количество €чеек в инвентаре")]
        [SerializeField] private int _maxCells = 20;

        [SerializeField] private List<InventoryCell> _inventory = new List<InventoryCell>();
        public List<InventoryCell> Inventory { get => _inventory; }

        public event Action<Item> AddItemToInventoryEvent; // событие добавлени€ предмета в инвентарь
        public event Action<Item> RemoveItemFromInventoryEvent; // событие удалени€ предмета из инвентар€

        /// <summary>
        /// ѕровер€ем, есть ли данный предмет в инвентаре
        /// </summary>
        private bool ItemHasBeenInventory(int id, out InventoryCell inventoryCell)
        {
            foreach (var item in _inventory)
            {
                if (item.IdItem == id)
                {
                    inventoryCell = item;
                    return true;
                }
            }

            inventoryCell = null;
            return false;
        }

        /// <summary>
        /// есть ли свободные €чейки в инвентаре
        /// </summary>
        private bool HasEmptyCell() => _inventory.Count < _maxCells;

        /// <summary>
        /// ƒобавл€ет предмет в инвентарь
        /// </summary>
        public bool AddItemToInventory(Item item)
        {
            if (item == null) return false;

            if (ItemHasBeenInventory(item.Id, out InventoryCell cell)) // если предмет есть в инвентаре
            {
                cell.AddItem(item); // добавл€ем его в €чейку
                AddItemToInventoryEvent?.Invoke(item); // запускаем событие
                return true; // предмет добавлен в инвентарь
            }
            else if (HasEmptyCell()) // если есть свободные €чейки
            {
                InventoryCell сell = new InventoryCell(item.Id, new List<Item> { item }); // создаем €чейку
                _inventory.Add(сell);  // добавл€ем ее
                AddItemToInventoryEvent?.Invoke(item);
                return true; // предмет добавлен в инвентарь
            }

            return false; // не удалость добавить предмет
        }

        /// <summary>
        /// ”дал€ет предмет из инвентар€
        /// </summary>
        public bool RemoveItemFromInventory(InventoryCell cell, Item item)
        {
            cell.RemoveItem(item); // удал€ем предмет
            if (cell.CountItems == 0) // если больше в €чейке нет предметов, то удал€ем €чейку            
                _inventory.Remove(cell);
            

            RemoveItemFromInventoryEvent?.Invoke(item); // обновл€ем
            return true;
        }

    }
}
