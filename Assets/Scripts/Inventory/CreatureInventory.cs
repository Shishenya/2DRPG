using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// ��������� ��������
/// </summary>
public class CreatureInventory : MonoBehaviour
{
    private Inventory _inventory; // ��������� ��������
    public Inventory Inventory { get => _inventory; }

    public event Action<int> AddItemToInventoryEvent; // ����� ���������� ��������
    public event Action<int> RemoveItemFromInventoryEvent; // ����� �������� ��������

    private void Awake()
    {
        _inventory = new Inventory(new List<Item>());
    }

    private void Start() { }

    /// <summary>
    /// ���������� �������� � ���������
    /// </summary>
    public void AddItemInInventory(Item item)
    {
        if (_inventory.AddItem(item))
        {
            AddItemToInventoryEvent?.Invoke(item.Id);
            Debug.Log($"�������� ������� � ��������");
        }
    }
}
