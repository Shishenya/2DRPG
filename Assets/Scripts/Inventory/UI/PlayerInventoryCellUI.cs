using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using Game.Inventory;
using Game.Items;

namespace UI.Game.Items
{
    /// <summary>
    /// Ячейка в инвентаре
    /// </summary>
    public class PlayerInventoryCellUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [Tooltip("Иконка предмета")]
        [SerializeField] private Image _image;

        [Tooltip("")]
        [SerializeField] private TMP_Text _countTMP;

        private InventoryCell _inventoryCell;
        private DescriptionPanelItemInInventory _desciptionPanel;
        private GameObject _player;
        private CreatureInventory _inventory;

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
                if (_inventoryCell._items[0] is IUsebaleItem usable)
                {
                    usable.Use(_player);
                    _inventory.RemoveItemFromInventory(_inventoryCell, _inventoryCell._items[0]);
                }
            }
        }
    }
}
