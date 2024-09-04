using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// ������ ��� ������ � ���������� ������
/// </summary>
public class PlayerInventoryCanvas : MonoBehaviour
{
    [Tooltip("��������� ��� ������ �� ������")]
    [SerializeField] private GameObject _background = null;

    [Tooltip("��������� ������")]
    [SerializeField] private CreatureInventory _creatureInventory;

    private List<PlayerInventoryCellUI> _cells; // ������ � ����������

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
    /// ���������� �����
    /// </summary>
    private void UpdateCells(int itemID)
    {
        for (int i = 0; i < _creatureInventory.Inventory.InventoryCells.Count; i++)        
            _cells[i].Init(_creatureInventory.Inventory.InventoryCells[i]);        
    }
}
