using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Game.Inventory;
using Game.Items;

namespace UI.Game.Items
{
    /// <summary>
    /// ������ ��� ������ � ���������� ������
    /// </summary>
    public class PlayerInventoryCanvas : MonoBehaviour
    {
        [Tooltip("��������� ��� ������ �� ������")]
        [SerializeField] private GameObject _background = null;

        [Tooltip("��������� ������")]
        [SerializeField] private CreatureInventory _creatureInventory;

        private List<PlayerInventoryCellUI> _cells = new List<PlayerInventoryCellUI>(); // ������ � ����������

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
        /// ���������� ����� � ����������
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