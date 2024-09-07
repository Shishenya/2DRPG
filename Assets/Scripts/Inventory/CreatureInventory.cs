using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Game.Items;

namespace Game.Inventory
{

    /// <summary>
    /// ��������� ��������
    /// </summary>
    public class CreatureInventory : MonoBehaviour
    {
        [Tooltip("������������ ���������� ����� � ���������")]
        [SerializeField] private int _maxCells = 20;

        [SerializeField] private List<InventoryCell> _inventory = new List<InventoryCell>();
        public List<InventoryCell> Inventory { get => _inventory; }

        public event Action<Item> AddItemToInventoryEvent; // ������� ���������� �������� � ���������
        public event Action<Item> RemoveItemFromInventoryEvent; // ������� �������� �������� �� ���������

        /// <summary>
        /// ���������, ���� �� ������ ������� � ���������
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
        /// ���� �� ��������� ������ � ���������
        /// </summary>
        private bool HasEmptyCell() => _inventory.Count < _maxCells;

        /// <summary>
        /// ��������� ������� � ���������
        /// </summary>
        public bool AddItemToInventory(Item item)
        {
            if (item == null) return false;

            if (ItemHasBeenInventory(item.Id, out InventoryCell cell)) // ���� ������� ���� � ���������
            {
                cell.AddItem(item); // ��������� ��� � ������
                AddItemToInventoryEvent?.Invoke(item); // ��������� �������
                return true; // ������� �������� � ���������
            }
            else if (HasEmptyCell()) // ���� ���� ��������� ������
            {
                InventoryCell �ell = new InventoryCell(item.Id, new List<Item> { item }); // ������� ������
                _inventory.Add(�ell);  // ��������� ��
                AddItemToInventoryEvent?.Invoke(item);
                return true; // ������� �������� � ���������
            }

            return false; // �� �������� �������� �������
        }

        /// <summary>
        /// ������� ������� �� ���������
        /// </summary>
        public bool RemoveItemFromInventory(InventoryCell cell, Item item)
        {
            cell.RemoveItem(item); // ������� �������
            if (cell.CountItems == 0) // ���� ������ � ������ ��� ���������, �� ������� ������            
                _inventory.Remove(cell);
            

            RemoveItemFromInventoryEvent?.Invoke(item); // ���������
            return true;
        }

    }
}
