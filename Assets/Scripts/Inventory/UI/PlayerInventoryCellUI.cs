using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using Game.Inventory;
using Game.Items;
using System.Collections.Generic;

namespace UI.Game.Items
{
    /// <summary>
    /// Ячейка в инвентаре
    /// </summary>
    public class PlayerInventoryCellUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerUpHandler, IPointerDownHandler
    {
        [Tooltip("Иконка предмета")]
        [SerializeField] private Image _image;

        [Tooltip("Количество предметов в ячейке (текстовое поле)")]
        [SerializeField] private TMP_Text _countTMP;

        [Tooltip("Иконка для перетаскивания")]
        [SerializeField] private GameObject _dragIcon = null;

        private InventoryCell _inventoryCell;
        private DescriptionPanelItemInInventory _desciptionPanel;
        private GameObject _player;
        private CreatureInventory _inventory;

        private bool _isDragging = false; // перетаскиваю иконку

        private Image _dragImage { get => _dragIcon.GetComponent<Image>(); }

        /// <summary>
        /// Инициализация и обновление
        /// </summary>
        public void Init(InventoryCell inventoryCell, DescriptionPanelItemInInventory desciptionPanel, GameObject player, CreatureInventory inventory)
        {
            _player = player;
            _inventoryCell = inventoryCell;
            _inventory = inventory;
            _image.sprite = GameItemsStorage.Instance.GetItemSOByID(inventoryCell.IdItem).Sprite;
            _countTMP.text = inventoryCell.CountItems.ToString();
            _desciptionPanel = desciptionPanel;
        }

        /// <summary>
        /// Очистка
        /// </summary>
        public void Clear()
        {
            _inventoryCell = null;
            _image.sprite = null;
            _countTMP.text = string.Empty;
        }

        private void OnDisable()
        {
            _isDragging = false;
            _dragIcon.SetActive(false);
            _dragImage.sprite = null;
        }

        /// <summary>
        /// навели мышкой - показали описание
        /// </summary>
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_inventoryCell == null) return;
            _desciptionPanel.Init(_inventoryCell._items[0]);
            _desciptionPanel.gameObject.SetActive(true);
        }

        /// <summary>
        /// Убрали мышку - убрали описание
        /// </summary>
        public void OnPointerExit(PointerEventData eventData)
        {
            _desciptionPanel?.gameObject.SetActive(false);
        }

        /// <summary>
        /// Кликнули по предмету ПКМ, значит используем его
        /// </summary>
        public void OnPointerClick(PointerEventData eventData)
        {
            if (_inventoryCell == null) return;
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                // Используемый предмет
                if (_inventoryCell._items[0] is IUsebaleItem usable)
                {
                    usable.Use(_player);
                    _inventory.RemoveItemFromInventory(_inventoryCell, _inventoryCell._items[0]);
                }

                // Одеваемый предмет
                if (_inventoryCell._items[0] is IWearable wearable)
                    wearable.Wearable(_player);
            }
        }

        /// <summary>
        /// Зажали ЛКМ
        /// </summary>
        void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                _isDragging = true;
                _dragImage.sprite = GameItemsStorage.Instance.GetItemSOByID(_inventoryCell.IdItem).Sprite;
                _dragIcon.SetActive(true);
            }
        }

        /// <summary>
        /// Отжали ЛКМ
        /// </summary>
        public void OnPointerUp(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                _isDragging = false;
                _dragImage.sprite = null;
                _dragIcon.SetActive(false);

                DeleteItemFromInventory(eventData);
            }
        }

        /// <summary>
        /// Перетаскивание иконки
        /// </summary>
        private void Update()
        {
            if (_isDragging)
                _dragIcon.transform.position = Input.mousePosition;
        }

        /// <summary>
        /// Удаление предмета из инвентаря
        /// </summary>
        private void DeleteItemFromInventory(PointerEventData eventData)
        {
            List<RaycastResult> raycastResult = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, raycastResult);

            if (raycastResult.Count > 0 && raycastResult[0].gameObject != null)
            {
                DeleteCellUI deleteComponent = raycastResult[0].gameObject.GetComponent<DeleteCellUI>();
                if (deleteComponent != null)
                {
                    Debug.Log("Удаляю предмет!");
                    _inventory.RemoveItemFromInventory(_inventoryCell, _inventoryCell.GetFirstItem());
                }
            }
        }
    }
}
