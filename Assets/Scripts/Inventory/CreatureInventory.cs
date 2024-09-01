using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Инвентарь существа
/// </summary>
public class CreatureInventory : MonoBehaviour
{
    private Inventory _inventory; // инвентарь существа

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
        _inventory.AddItem(item);
        Debug.Log($"Добавили предмет в инветарь");
    }
}
