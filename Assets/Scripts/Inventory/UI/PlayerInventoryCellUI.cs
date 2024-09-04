using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Ячейка в инвентаре
/// </summary>
public class PlayerInventoryCellUI : MonoBehaviour
{
    [Tooltip("ID ячейки")]
    [SerializeField] private int _idCell;

    public int IdCell { get => _idCell; }

    [Tooltip("Картинка с иконкой предмета")]
    [SerializeField] private Image _cellImage;

    [Tooltip("TMP с количеством предметов")]
    [SerializeField] private TMP_Text _countText;

    private int _currentIdItem = -1;

    /// <summary>
    /// Инициализация
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
    /// Обновление рисунка с предметом
    /// </summary>
    private void UpdateImage() =>    
        _cellImage.sprite = GameItemsStorage.Instance.GetItemSOByID(_currentIdItem).Sprite;
    
    /// <summary>
    /// Обновление количества предметов
    /// </summary>
    private void UpdateCount(int count) =>    
        _countText.text = count.ToString();
    
}
