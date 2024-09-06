using Game.Inventory;
using Game.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Game.Items
{

    /// <summary>
    /// ������ ��� ������ � ����������, ������� ����� �� �����
    /// </summary>
    public class ItemsInGroundCanvas : MonoBehaviour
    {
        [Tooltip("������ � ����������")]
        [SerializeField] private GameObject _backgroundPanel = null;

        [Tooltip("���� �������� ������ � ����������")]
        [SerializeField] private Transform _contetnParent = null;

        [Tooltip("������ � �������")]
        [SerializeField] private GameObject _prefabIcon = null;

        [Tooltip("")]
        [SerializeField] private GameObject _descriptionPanel = null;

        [Tooltip("��������� ������")]
        [SerializeField] private CreatureInventory _playerInventory = null;

        private ItemsInGround _itemsInGround = null; // � ������ ���������� �� ��������

        private static ItemsInGroundCanvas _itemsInGroundCanvas = null;
        public static ItemsInGroundCanvas Instance { get => _itemsInGroundCanvas; }

        private List<GameObject> _iconsList = new List<GameObject>();


        private void Awake()
        {
            _itemsInGroundCanvas = this; // Instance
            
            //_playerInventory.AddItemToInventoryEvent+=
        }

        /// <summary>
        /// ������������
        /// </summary>
        public void Init(ItemsInGround itemsInGround)
        {

            ClearIcons();

            _itemsInGround = itemsInGround; // �������� ��������, �� ������� ���������
            _itemsInGround.RemoveItemEvent += UpdateIcons; // ��� �������� �������� �������������� ������ � �������
            _itemsInGround.IsEmptyItemsEvent += ReInit; // ���� ����������� ��������, �� ��������
            CreateIcons(); // ������� ������
            _backgroundPanel.SetActive(true); // �������� ������
        }

        /// <summary>
        /// ���������� ������ � ����������
        /// </summary>
        public void ReInit()
        {
            _backgroundPanel.SetActive(false);
            if (_itemsInGround!=null) _itemsInGround.RemoveItemEvent -= UpdateIcons;
            if (_itemsInGround != null)  _itemsInGround.IsEmptyItemsEvent -= ReInit;
            _itemsInGround = null;
        }

        /// <summary>
        ///  ���������� ������
        /// </summary>
        private void UpdateIcons(Item item)
        {
            // ���� ������ ������
            int index = -1;
            for (int i = 0; i < _iconsList.Count; i++)
            {
                if (_iconsList[i].GetComponent<IconInItemInGround>().CurrentItem == item)
                {
                    index = i;
                    break;
                }
            }

            // ������� ������ �� ������
            if (index != -1)
            {
                Destroy(_iconsList[index]);
                _iconsList.RemoveAt(index);
            }
        }

        /// <summary>
        /// �������� ������
        /// </summary>
        private void CreateIcons()
        {
            foreach (var item in _itemsInGround.Items)
            {
                GameObject iconGO = Instantiate(_prefabIcon, _contetnParent);
                IconInItemInGround icon = iconGO.GetComponent<IconInItemInGround>();
                icon.Init(item, _descriptionPanel, _playerInventory, _itemsInGround);
                _iconsList.Add(iconGO);
            }
        }

        /// <summary>
        /// ������� ������ � ����������
        /// </summary>
        private void ClearIcons()
        {
            foreach (var item in _iconsList)
                Destroy(item);

            _iconsList.Clear();
        }
    }
}
