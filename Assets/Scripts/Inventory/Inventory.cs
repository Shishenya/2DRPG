using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Инвентарь
/// </summary>
[System.Serializable]
public class Inventory
{
    private int _maxCells = 20; // максимльное количество ячеек в инвентаре
    private List<InventoryCell> _inventoryCells = new List<InventoryCell>(); // ячейки с предметами

    public List<InventoryCell> InventoryCells { get => _inventoryCells; }

    /// <summary>
    /// Конструктор со списком предметов, которые мы добавляем в начале
    /// </summary>
    public Inventory(List<Item> items)
    {

    }

    /// <summary>
    /// Добавление предмет в инвентарь
    /// </summary>
    public bool AddItem(Item item)
    {
        // если предмет есть в инвентаре
        int cell = GetCellByItemID(item.Id);
        if (cell != -1)
        {
            _inventoryCells[cell].UpdateCount(item.Id, 1);
            return true;
        }
        else if (HasBeenCell(out int emptyCell)) // если предмета нет в инвентаре, но есть свободная ячейка
        {
            InventoryCell inventoryCell = new InventoryCell(item.Id, 1);
            _inventoryCells.Add(inventoryCell);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Проверяем, есть ли свободная ячейка в инвентаре и возвращает ее номер
    /// </summary>
    public bool HasBeenCell(out int emptyCell)
    {
        if (_inventoryCells.Count > _maxCells)
        {
            emptyCell = -1;
            return false;
        }
        else
        {
            emptyCell = _inventoryCells.Count;
            return true;
        }
    }

    /// <summary>
    /// Возвращает номер ячейки с предметом ID
    /// </summary>
    public int GetCellByItemID(int id)
    {
        for (int i = 0; i < _inventoryCells.Count; i++)
            if (_inventoryCells[i].IdItem == id) return i;

        return -1;
    }
}
