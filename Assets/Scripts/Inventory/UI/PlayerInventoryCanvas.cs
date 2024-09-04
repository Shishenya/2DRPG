using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Канвас для работы с инвентарем игрока
/// </summary>
public class PlayerInventoryCanvas : MonoBehaviour
{
    [Tooltip("Бэкгроунд для вызова по кнопке")]
    [SerializeField] private GameObject _background = null;

    [Tooltip("Инвентарь игрока")]
    [SerializeField] private CreatureInventory _creatureInventory;

    private List<PlayerInventoryCellUI> _cells; // ячейки с предметами

    private KeyCode _inventoryKey = KeyCode.Tab;

    private void Awake()
    {
        _cells = GetComponentsInChildren<PlayerInventoryCellUI>(true).ToList();
    }

    private void OnEnable()
    {
        _creatureInventory.AddItemToInventoryEvent += UpdateCells;
        UpdateCells(-1);
    }

    private void OnDisable()
    {
        _creatureInventory.AddItemToInventoryEvent -= UpdateCells;
    }

    private void Update()
    {
        if (Input.GetKeyDown(_inventoryKey))
            _background.SetActive(!_background.activeInHierarchy);
    }

    /// <summary>
    /// Обновление ячеек
    /// </summary>
    private void UpdateCells(int itemID)
    {
        for (int i = 0; i < _creatureInventory.Inventory.InventoryCells.Count; i++)        
            _cells[i].Init(_creatureInventory.Inventory.InventoryCells[i]);        
    }
}
