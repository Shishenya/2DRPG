using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ���������
/// </summary>
[System.Serializable]
public class Inventory
{
    private int _maxCells = 20; // ����������� ���������� ����� � ���������
    private List<InventoryCell> _inventoryCells = new List<InventoryCell>(); // ������ � ����������

    public List<InventoryCell> InventoryCells { get => _inventoryCells; }

    /// <summary>
    /// ����������� �� ������� ���������, ������� �� ��������� � ������
    /// </summary>
    public Inventory(List<Item> items)
    {

    }

    /// <summary>
    /// ���������� ������� � ���������
    /// </summary>
    public bool AddItem(Item item)
    {
        // ���� ������� ���� � ���������
        int cell = GetCellByItemID(item.Id);
        if (cell != -1)
        {
            _inventoryCells[cell].UpdateCount(item.Id, 1);
            return true;
        }
        else if (HasBeenCell(out int emptyCell)) // ���� �������� ��� � ���������, �� ���� ��������� ������
        {
            InventoryCell inventoryCell = new InventoryCell(item.Id, 1);
            _inventoryCells.Add(inventoryCell);
            return true;
        }

        return false;
    }

    /// <summary>
    /// ���������, ���� �� ��������� ������ � ��������� � ���������� �� �����
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
    /// ���������� ����� ������ � ��������� ID
    /// </summary>
    public int GetCellByItemID(int id)
    {
        for (int i = 0; i < _inventoryCells.Count; i++)
            if (_inventoryCells[i].IdItem == id) return i;

        return -1;
    }
}
