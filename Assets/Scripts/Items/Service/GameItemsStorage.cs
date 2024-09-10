using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Items
{
    /// <summary>
    /// ������ ��� ������ � ����������
    /// </summary>
    public class GameItemsStorage : MonoBehaviour
    {

        private static GameItemsStorage _gameItems;
        public static GameItemsStorage Instance { get => _gameItems; }

        [Tooltip("��������, ������� ���� � ����")]
        [SerializeField] private List<Item_SO> _items_SO;

        [Tooltip("��������� ������ ��� ���� ���������")]
        [SerializeField] private Sprite _defaultSprite;
        public Sprite DefaultSprite { get => _defaultSprite; }

        private Dictionary<int, Item_SO> _itemsDictionary = new Dictionary<int, Item_SO>();
        public Dictionary<int, Item_SO> ItemsDictionary { get => _itemsDictionary; }

        private void Awake()
        {
            DontDestroyOnLoad(this);
            _gameItems = this;
            CreateDictonary(); // ������� ������� �� ����� ����������
        }

        /// <summary>
        /// �������� �������
        /// </summary>
        private void CreateDictonary()
        {
            _itemsDictionary.Clear();
            foreach (var item in _items_SO)
                _itemsDictionary.Add(item.Id, item);
        }

        /// <summary>
        /// ���������� �������� �������� �� ��� ID
        /// </summary>
        public Item_SO GetItemSOByID(int id)
        {
            if (_itemsDictionary.ContainsKey(id))
                return _itemsDictionary[id];

            return null;
        }

        /// <summary>
        /// �������� �������� �� ��� ID
        /// </summary>
        public Item CreateItem(int id)
        {
            Item_SO item_SO = GetItemSOByID(id);
            switch (item_SO.Type)
            {
                case ItemType.Undefiend: // ���� ������� �� ��������� ��� �������� �������
                case ItemType.Trash:
                    Item item = new Item(id);
                    return item;
                case ItemType.Food: // ���� ������� ���
                    Food food = new Food(id);
                    return food;
                case ItemType.Weapon:
                    break;
                case ItemType.Armor:
                    Armor armor = new Armor(id);
                    return armor;
                default:
                    break;
            }

            return null;
        }
    }
}
