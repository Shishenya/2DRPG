using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��������� ��������
/// </summary>
public class CreatureInventory : MonoBehaviour
{
    private Inventory _inventory; // ��������� ��������

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
        _inventory.AddItem(item);
        Debug.Log($"�������� ������� � ��������");
    }
}
