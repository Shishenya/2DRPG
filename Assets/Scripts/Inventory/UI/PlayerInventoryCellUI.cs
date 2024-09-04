using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// ������ � ���������
/// </summary>
public class PlayerInventoryCellUI : MonoBehaviour
{
    [Tooltip("ID ������")]
    [SerializeField] private int _idCell;

    public int IdCell { get => _idCell; }

    [Tooltip("�������� � ������� ��������")]
    [SerializeField] private Image _cellImage;

    [Tooltip("TMP � ����������� ���������")]
    [SerializeField] private TMP_Text _countText;

    private int _currentIdItem = -1;

    /// <summary>
    /// �������������
    /// </summary>
    public void Init(InventoryCell inventoryCell)
    {
        if (inventoryCell.IdItem != _currentIdItem)
        {
            _currentIdItem = inventoryCell.IdItem;
            UpdateImage();
            UpdateCount(inventoryCell.Count);
        }
        else
        {
            UpdateCount(inventoryCell.Count);
        }
    }

    /// <summary>
    /// ���������� ������� � ���������
    /// </summary>
    private void UpdateImage() =>    
        _cellImage.sprite = GameItemsStorage.Instance.GetItemSOByID(_currentIdItem).Sprite;
    
    /// <summary>
    /// ���������� ���������� ���������
    /// </summary>
    private void UpdateCount(int count) =>    
        _countText.text = count.ToString();
    
}
