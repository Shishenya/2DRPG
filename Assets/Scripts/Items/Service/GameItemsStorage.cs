using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Items
{
    /// <summary>
    /// Сервис для работы с предметами
    /// </summary>
    public class GameItemsStorage : MonoBehaviour
    {

        private static GameItemsStorage _gameItems;
        public static GameItemsStorage Instance { get => _gameItems; }

        [Tooltip("Предметы, которые есть в игре")]
        [SerializeField] private List<Item_SO> _items_SO;

        [Tooltip("Дефолтный спрайт для кучи предметов")]
        [SerializeField] private Sprite _defaultSprite;
        public Sprite DefaultSprite { get => _defaultSprite; }

        private Dictionary<int, Item_SO> _itemsDictionary = new Dictionary<int, Item_SO>();
        public Dictionary<int, Item_SO> ItemsDictionary { get => _itemsDictionary; }

        private void Awake()
        {
            DontDestroyOnLoad(this);
            _gameItems = this;
            CreateDictonary(); // содание словаря со всеми предметами
        }

        /// <summary>
        /// Создание словаря
        /// </summary>
        private void CreateDictonary()
        {
            _itemsDictionary.Clear();
            foreach (var item in _items_SO)
                _itemsDictionary.Add(item.Id, item);
        }

        /// <summary>
        /// Возвращает описание предмета по его ID
        /// </summary>
        public Item_SO GetItemSOByID(int id)
        {
            if (_itemsDictionary.ContainsKey(id))
                return _itemsDictionary[id];

            return null;
        }

        /// <summary>
        /// Создание предмета по его ID
        /// </summary>
        public Item CreateItem(int id)
        {
            Item_SO item_SO = GetItemSOByID(id);
            switch (item_SO.Type)
            {
                case ItemType.Undefiend: // если предмет не определен или является мусором
                case ItemType.Trash:
                    Item item = new Item(id);
                    return item;
                case ItemType.Food: // если предмет еда
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
