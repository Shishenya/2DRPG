using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Работа с канвасом, который отображаетпредметы на земле
/// </summary>
public class ItemsInGroundCanvas : MonoBehaviour
{
    [Tooltip("Панель с предметами")]
    [SerializeField] private GameObject _backgroundPanel = null;

    [Tooltip("Родитель для всех предметов, которые лежат на земле (панель)")]
    [SerializeField] private Transform _parentForItems = null;

    [Tooltip("Префаб с иконкой для предмета на земле")]
    [SerializeField] private GameObject _itemInGroundIconPrefab = null;

    [Tooltip("Инвентарь игрока")]
    [SerializeField]private CreatureInventory _playerInventory = null;

    [Tooltip("Панель с описанием премета")]
    [SerializeField] private GameObject _descriptionItemPanel = null;

    private static ItemsInGroundCanvas _itemsInGroundCanvas;
    public static ItemsInGroundCanvas Instance { get => _itemsInGroundCanvas;  }

    private Items _currentItems = null; // список предметов
    private List<GameObject> _currentItemsList = new List<GameObject>(); // GO с иконками для этих предметов


    private void Awake()
    {
        _itemsInGroundCanvas = this;
    }

    /// <summary>
    /// Создание панели с предметами
    /// </summary>
    public void Init(Items items)
    {
        _currentItemsList.Clear();
        _backgroundPanel.SetActive(true);
        _currentItems = items;

        CreateItemsInPanel();
    }

    /// <summary>
    /// Отключение панели с предметами
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
