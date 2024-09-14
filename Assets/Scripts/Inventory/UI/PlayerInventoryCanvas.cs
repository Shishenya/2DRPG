using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Game.Inventory;
using Game.Items;
using Player.Move;

namespace UI.Game.Items
{
    /// <summary>
    /// Канвас для работы с инвентарем игрока
    /// </summary>
    public class PlayerInventoryCanvas : MonoBehaviour
    {
        [Tooltip("Бэкгроунд для вызова по кнопке")]
        [SerializeField] private GameObject _background = null;

        [Tooltip("Панель с описанием")]
        [SerializeField] private DescriptionPanelItemInInventory _desciptionPanel;

        [Tooltip("Инвентарь игрока")]
        [SerializeField] private CreatureInventory _creatureInventory;

        [Tooltip("Компонент отвечающий за движения игрока")]
        [SerializeField] private PlayerMove _playerMove = null;

        private List<PlayerInventoryCellUI> _cells = new List<PlayerInventoryCellUI>(); // ячейки с предметами

        private KeyCode _inventoryKey = KeyCode.Tab;

        private void Awake()
        {
            _cells = GetComponentsInChildren<PlayerInventoryCellUI>(true).ToList();
        }

        private void OnEnable()
        {
            _creatureInventory.AddItemToInventoryEvent += UpdateInventoryCanvas;
            _creatureInventory.RemoveItemFromInventoryEvent += UpdateInventoryCanvas;
            UpdateInventoryCanvas(null);
        }

        private void OnDisable()
        {
            _creatureInventory.AddItemToInventoryEvent -= UpdateInventoryCanvas;
            _creatureInventory.RemoveItemFromInventoryEvent -= UpdateInventoryCanvas;
        }

        /// <summary>
        /// Обновление ячеек с инвентарем
        /// </summary>
        private void UpdateInventoryCanvas(Item item)
        {
            for (int i = 0; i < _creatureInventory.Inventory.Count; i++)           
                _cells[i].Init(_creatureInventory.Inventory[i], _desciptionPanel, _creatureInventory.gameObject, _creatureInventory);
            
            for (int i = _creatureInventory.Inventory.Count; i < _cells.Count; i++)            
                _cells[i].Clear();            
        }

        private void Update()
        {
            if (Input.GetKeyDown(_inventoryKey))
                LoadInventory();
        }

        /// <summary>
        /// Загрущка и выгрущка панели с инвентарем
        /// </summary>
        private void LoadInventory()
        {
            _background.SetActive(!_background.activeInHierarchy);
            if (_background.activeInHierarchy == false) _desciptionPanel.gameObject.SetActive(false);
            _playerMove.enabled = !_background.activeInHierarchy;
        }

    }
}