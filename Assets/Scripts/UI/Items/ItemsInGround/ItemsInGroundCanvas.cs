using Game.Inventory;
using Game.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Game.Items
{

    /// <summary>
    /// Канвас для работы с предметами, которые лежат на земле
    /// </summary>
    public class ItemsInGroundCanvas : MonoBehaviour
    {
        [Tooltip("Панель с предметами")]
        [SerializeField] private GameObject _backgroundPanel = null;

        [Tooltip("Куда помещать иконки с предметами")]
        [SerializeField] private Transform _contetnParent = null;

        [Tooltip("Префаб с иконкой")]
        [SerializeField] private GameObject _prefabIcon = null;

        [Tooltip("")]
        [SerializeField] private GameObject _descriptionPanel = null;

        [Tooltip("Инвентарь игрока")]
        [SerializeField] private CreatureInventory _playerInventory = null;

        private ItemsInGround _itemsInGround = null; // с какими предметами мы работаем

        private static ItemsInGroundCanvas _itemsInGroundCanvas = null;
        public static ItemsInGroundCanvas Instance { get => _itemsInGroundCanvas; }

        private List<GameObject> _iconsList = new List<GameObject>();


        private void Awake()
        {
            _itemsInGroundCanvas = this; // Instance
            
            //_playerInventory.AddItemToInventoryEvent+=
        }

        /// <summary>
        /// Иницализация
        /// </summary>
        public void Init(ItemsInGround itemsInGround)
        {

            ClearIcons();

            _itemsInGround = itemsInGround; // получаем предмкты, на которые наступили
            _itemsInGround.RemoveItemEvent += UpdateIcons; // При удалении предмета перерисовываем иконки в канвасе
            _itemsInGround.IsEmptyItemsEvent += ReInit; // если закончились предметы, то вырубаем
            CreateIcons(); // создаем иконки
            _backgroundPanel.SetActive(true); // включаем панель
        }

        /// <summary>
        /// Выключение панели с предметами
        /// </summary>
        public void ReInit()
        {
            _backgroundPanel.SetActive(false);
            if (_itemsInGround!=null) _itemsInGround.RemoveItemEvent -= UpdateIcons;
            if (_itemsInGround != null)  _itemsInGround.IsEmptyItemsEvent -= ReInit;
            _itemsInGround = null;
        }

        /// <summary>
        ///  Обновление иконок
        /// </summary>
        private void UpdateIcons(Item item)
        {
            // Ищем индекс иконки
            int index = -1;
            for (int i = 0; i < _iconsList.Count; i++)
            {
                if (_iconsList[i].GetComponent<IconInItemInGround>().CurrentItem == item)
                {
                    index = i;
                    break;
                }
            }

            // Удаляем икноку из списка
            if (index != -1)
            {
                Destroy(_iconsList[index]);
                _iconsList.RemoveAt(index);
            }
        }

        /// <summary>
        /// Создание иконок
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
        /// Очистка списка с предметами
        /// </summary>
        private void ClearIcons()
        {
            foreach (var item in _iconsList)
                Destroy(item);

            _iconsList.Clear();
        }
    }
}
