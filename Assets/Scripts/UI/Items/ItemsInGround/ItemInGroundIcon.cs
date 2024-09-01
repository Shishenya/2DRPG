using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


/// <summary>
/// ������ � ��������� �� ����� � �������
/// </summary>
public class ItemInGroundIcon : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Image _image;
    private Item_SO _item_SO;
    private CreatureInventory _playerInventory;
    private GameObject _descriptionPanel;
    private Item _currentItem = null;

    [Tooltip("���� ������� ��� ���������")]
    [SerializeField] private Color _hoverColor = Color.yellow;
    private Color _originalColor; // ������������ ����

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
    /// ������������� ������ � ���������
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
            Debug.Log("������� ������� ��� ��������� ��� � ���������");
            CreateItem();
        }
    }

    /// <summary>
    /// �������� �������� ��� ���������� ��� � ���������
    /// </summary>
    private void CreateItem()
    {        
        Debug.Log("����� �������� �������� � ������� ����� �� ������");
        _playerInventory.AddItemInInventory(_currentItem);
    }

    /// <summary>
    /// ������ ������ �� �������, ���� �������� ��������� �� ����
    /// </summary>
    public void OnPointerEnter(PointerEventData eventData)
    {
        _descriptionPanel.SetActive(true);
        _descriptionPanel.GetComponent<DescriptionPanelItemInGround>()?.Init(_currentItem);
        _image.color = _hoverColor;
    }

    /// <summary>
    /// ������ ����� � �������� - ������� ���������
    /// </summary>
    public void OnPointerExit(PointerEventData eventData)
    {
        _descriptionPanel.SetActive(false);
        _descriptionPanel.GetComponent<DescriptionPanelItemInGround>()?.ReInit();
        _image.color = _originalColor;
    }
}
