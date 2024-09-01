using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���������
/// </summary>
[System.Serializable]
public class Inventory
{
    public List<Item> _items;

    public Inventory(List<Item> items)
    {
        _items = items;
    }

    /// <summary>
    /// ���������� ������� � ���������
    /// </summary>
    public void AddItem(Item item)
    {
        _items.Add(item);
    }

}
