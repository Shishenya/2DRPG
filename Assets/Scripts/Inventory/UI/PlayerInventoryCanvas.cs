using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Game.Inventory;

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
