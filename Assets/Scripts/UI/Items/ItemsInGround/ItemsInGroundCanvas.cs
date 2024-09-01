using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������ � ��������, ������� ������������������ �� �����
/// </summary>
public class ItemsInGroundCanvas : MonoBehaviour
{
    [Tooltip("������ � ����������")]
    [SerializeField] private GameObject _backgroundPanel = null;

    [Tooltip("�������� ��� ���� ���������, ������� ����� �� ����� (������)")]
    [SerializeField] private Transform _parentForItems = null;

    [Tooltip("������ � ������� ��� �������� �� �����")]
    [SerializeField] private GameObject _itemInGroundIconPrefab = null;

    [Tooltip("��������� ������")]
    [SerializeField]private CreatureInventory _playerInventory = null;

    [Tooltip("������ � ��������� �������")]
    [SerializeField] private GameObject _descriptionItemPanel = null;

    private static ItemsInGroundCanvas _itemsInGroundCanvas;
    public static ItemsInGroundCanvas Instance { get => _itemsInGroundCanvas;  }

    private Items _currentItems = null; // ������ ���������
    private List<GameObject> _currentItemsList = new List<GameObject>(); // GO � �������� ��� ���� ���������


    private void Awake()
    {
        _itemsInGroundCanvas = this;
    }

    /// <summary>
    /// �������� ������ � ����������
    /// </summary>
    public void Init(Items items)
    {
        _currentItemsList.Clear();
        _backgroundPanel.SetActive(true);
        _currentItems = items;

        CreateItemsInPanel();
    }

    /// <summary>
    /// ���������� ������ � ����������
    /// </summary>
    public void ReInit()
    {
        _backgroundPanel.SetActive(false);
        _currentItems = null;

        foreach (var item in _currentItemsList)        
            Destroy(item);

        _currentItemsList.Clear();
    }

    private void CreateItemsInPanel()
    {
        foreach (var item in _currentItems.items)
        {
            GameObject current = Instantiate(_itemInGroundIconPrefab, _parentForItems);
            ItemInGroundIcon itemInGround = current.GetComponent<ItemInGroundIcon>();
            itemInGround.Init(item, _playerInventory, _descriptionItemPanel);
            _currentItemsList.Add(current);
        }
    }
}
