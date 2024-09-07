using Game.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Game.Inventory;

namespace UI.Game.Items
{
    /// <summary>
    /// ������ �� ������ ���������, ������� ����� �� �����
    /// </summary>
    public class IconInItemInGround : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [Tooltip("������ ��������")]
        [SerializeField] private Image _image;       

        private Item _currentItem; // ������� �������
        public Item CurrentItem { get => _currentItem; }
        private DescriptionPanelItemInGround _descriptionPanel; // ������ � ��������� ��������
        private CreatureInventory _inventory = null; // ��������� ������
        private ItemsInGround _itemsInGround = null; // ������ ������� ��������

        private readonly Color _hoverColor = Color.yellow;
        private Color _originColor;

        public void Init(Item currentItem, GameObject descriptionPanel, CreatureInventory inventory, ItemsInGround itemsInGround)
        {
            _currentItem = currentItem;
            _descriptionPanel = descriptionPanel.GetComponent<DescriptionPanelItemInGround>();
            _inventory = inventory;
            _itemsInGround = itemsInGround;

            _originColor = _image.color;

            ChangeImage();
        }

        /// <summary>
        /// ������ ������ �� ������
        /// </summary>
        public void OnPointerEnter(PointerEventData eventData)
        {
            _descriptionPanel.Init(_currentItem);
            _image.color = _hoverColor;
        }

        /// <summary>
        /// ������ ����� � ������
        /// </summary>
        public void OnPointerExit(PointerEventData eventData)
        {
            DisableDesciptionPanel();
            _image.color = _originColor;
        }

        /// <summary>
        /// ���������� ������ � ����������
        /// </summary>
        private void DisableDesciptionPanel()
        {
            _descriptionPanel.ReInit();
            _image.color = _originColor;
        }

        private void OnDisable()
        {
            _inventory = null;
            _descriptionPanel.ReInit();
            _image.color = _originColor;
        }

        /// <summary>
        /// ��������� ������ ��������
        /// </summary>
        private void ChangeImage() => _image.sprite = GameItemsStorage.Instance.GetItemSOByID(_currentItem.Id).Sprite;

        /// <summary>
        /// �������� �� ������ - ��������� � ���������
        /// </summary>
        public void OnPointerClick(PointerEventData eventData)
        {
            if (_inventory.AddItemToInventory(_currentItem)) // ���� �������� ������� � ���������, �� ������� ��� �� ������ ������
            {
                _itemsInGround.RemoveItem(_currentItem); // ������� ������� � �����
            }
        }
    }
}
