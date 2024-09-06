using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Game.Inventory;
using Game.Items;

namespace UI.Game.Items
{
    /// <summary>
    /// Канвас для работы с инвентарем игрока
    /// </summary>
    public class PlayerInventoryCanvas : MonoBehaviour
    {
        [Tooltip("Бэкгроунд для вызова по кнопке")]
        [SerializeField] private GameObject _background = null;

        [Tooltip("Инвентарь игрока")]
        [SerializeField] private CreatureInventory _creatureInventory;

        private List<PlayerInventoryCellUI> _cells = new List<PlayerInventoryCellUI>(); // ячейки с предметами

        private KeyCode _inventoryKey = KeyCode.Tab;

        private void Awake()
        {
            _cells = GetComponentsInChildren<PlayerInventoryCellUI>(true).ToList();
        }

        private void OnEnable()
        {
            _creatureInventory.AddItemToInventoryEvent += UpdateInventoryCanvas;
            UpdateInventoryCanvas(null);
        }

        private void OnDisable()
        {
            _creatureInventory.AddItemToInventoryEvent -= UpdateInventoryCanvas;
        }

        /// <summary>
        /// Обновление ячеек с инвентарем
        /// </summary>
        private void UpdateInventoryCanvas(Item item)
        {
            for (int i = 0; i < _creatureInventory.Inventory.Count; i++)           
                _cells[i].Init(_creatureInventory.Inventory[i]);
            
            for (int i = _creatureInventory.Inventory.Count; i < _cells.Count; i++)            
                _cells[i].Clear();            
        }

        private void Update()
        {
            if (Input.GetKeyDown(_inventoryKey))            
                _background.SetActive(!_background.activeInHierarchy);            
        }

    }
}