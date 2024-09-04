using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Инвентарь существа
/// </summary>
public class CreatureInventory : MonoBehaviour
{
    private Inventory _inventory; // инвентарь существа
    public Inventory Inventory { get => _inventory; }

    public event Action<int> AddItemToInventoryEvent; // эвент добавление предмета
    public event Action<int> RemoveItemFromInventoryEvent; // эвент удаления предмета

    private void Awake()
    {
        _inventory = new Inventory(new List<Item>());
    }

    private void Start() { }

    /// <summary>
    /// Добавление предмета в инвентарь
    /// </summary>
    public void AddItemInInventory(Item item)
    {
        if (_inventory.AddItem(item))
        {
            AddItemToInventoryEvent?.Invoke(item.Id);
            Debug.Log($"Добавили предмет в инветарь");
        }
    }
}
