using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Game.Inventory;

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

    }

    private void OnDisable()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(_inventoryKey))
            _background.SetActive(!_background.activeInHierarchy);
    }

}
