using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


/// <summary>
/// Иконка с предметом на земле в канвасе
/// </summary>
public class ItemInGroundIcon : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Image _image;
    private Item_SO _item_SO;
    private CreatureInventory _playerInventory;
    private GameObject _descriptionPanel;
    private Item _currentItem = null;

    [Tooltip("Цвет обводки при наведении")]
    [SerializeField] private Color _hoverColor = Color.yellow;
    private Color _originalColor; // оригинальный цвет

    private void Awake()
    {
        _image = GetComponent<Image>();
        _originalColor = _image.color;
    }

    private void OnDisable()
    {
        _descriptionPanel.SetActive(false);
        _descriptionPanel.GetComponent<DescriptionPanelItemInGround>()?.ReInit();
        _image.color = _originalColor;
    }

    /// <summary>
    /// Инициализация иконки с предметом
    /// </summary>
    public void Init(int id, CreatureInventory creatureInventory, GameObject descriptionPanel)
    {
        _playerInventory = creatureInventory;
        _item_SO = GameItemsStorage.Instance.GetItemSOByID(id);
        _descriptionPanel = descriptionPanel;
        if (_item_SO != null)
        {
            _image.sprite = _item_SO.Sprite;
            _currentItem = GameItemsStorage.Instance.CreateItem(_item_SO.Id);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("Создаем предмет для добвления его в инвентарь");
            CreateItem();
        }
    }

    /// <summary>
    /// Создание предмета для добавления его в инвентарь
    /// </summary>
    private void CreateItem()
    {        
        Debug.Log("Конец создание предмета в скрипте клика по иконке");
        _playerInventory.AddItemInInventory(_currentItem);
    }

    /// <summary>
    /// Навели мышкой на предмет, надо показать подсказку по нему
    /// </summary>
    public void OnPointerEnter(PointerEventData eventData)
    {
        _descriptionPanel.SetActive(true);
        _descriptionPanel.GetComponent<DescriptionPanelItemInGround>()?.Init(_currentItem);
        _image.color = _hoverColor;
    }

    /// <summary>
    /// Убрали мышку с предмета - убираем подсказку
    /// </summary>
    public void OnPointerExit(PointerEventData eventData)
    {
        _descriptionPanel.SetActive(false);
        _descriptionPanel.GetComponent<DescriptionPanelItemInGround>()?.ReInit();
        _image.color = _originalColor;
    }
}
