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
    /// Иконка на панели предметов, которые лежат на земле
    /// </summary>
    public class IconInItemInGround : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [Tooltip("Иконка предмета")]
        [SerializeField] private Image _image;

        private Item _currentItem; // текущий предмет
        public Item CurrentItem { get => _currentItem; }
        private DescriptionPanelItemInGround _descriptionPanel; // Панель с описанием предмета
        private CreatureInventory _inventory = null; // инвентарь игрока
        private ItemsInGround _itemsInGround = null; // откуда берутся предметы

        public void Init(Item currentItem, GameObject descriptionPanel, CreatureInventory inventory, ItemsInGround itemsInGround)
        {
            _currentItem = currentItem;
            _descriptionPanel = descriptionPanel.GetComponent<DescriptionPanelItemInGround>();
            _inventory = inventory;
            _itemsInGround = itemsInGround;

            ChangeImage();
        }

        /// <summary>
        /// Навели мышкой на иконку
        /// </summary>
        public void OnPointerEnter(PointerEventData eventData)
        {
            _descriptionPanel.Init(_currentItem);
        }

        /// <summary>
        /// Убрали мышку с иконки
        /// </summary>
        public void OnPointerExit(PointerEventData eventData)
        {
            DisableDesciptionPanel();
        }

        /// <summary>
        /// Выключание панели с подсказкой
        /// </summary>
        private void DisableDesciptionPanel()
        {
            _descriptionPanel.ReInit();
        }

        private void OnDisable()
        {
            _inventory = null;
            _descriptionPanel.ReInit();
        }

        /// <summary>
        /// Изменение иконки предмета
        /// </summary>
        private void ChangeImage() => _image.sprite = GameItemsStorage.Instance.GetItemSOByID(_currentItem.Id).Sprite;

        /// <summary>
        /// Кликнули по иконке - добавляем в инвентарь
        /// </summary>
        public void OnPointerClick(PointerEventData eventData)
        {
            if (_inventory.AddInventory(_currentItem)) // есди добавили предмет в инвентарь, то удаляем его из панели иконок
            {
                _itemsInGround.RemoveItem(_currentItem); // удаляем предмет с земли
            }
        }
    }
}
