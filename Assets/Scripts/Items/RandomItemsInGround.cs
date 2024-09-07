using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Items
{
 /// <summary>
 /// Рандомные предметы на земле
 /// </summary>
    public class RandomItemsInGround : ItemsInGround
    {
        [Tooltip("Список рандомных предметов на выпадение")]
        [SerializeField] private List<RandomItemChance> _randomItems = new List<RandomItemChance>();

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            CreateItems();
            ChangeIcons();
        }

        /// <summary>
        /// Создание предметов
        /// </summary>
        private void CreateItems()
        {
            foreach (var randomItem in _randomItems)
            {
                if (SuccessfulChance(randomItem.chance)) // если попали в шанс
                {
                    Item item = GameItemsStorage.Instance.CreateItem(randomItem.idItem);
                    _items.Add(item);
                }
            }
        }

        /// <summary>
        /// Успешный ли шанс на создание предмета
        /// </summary>
        private bool SuccessfulChance(float chance) => chance >= Random.Range(0, 100);
    }
}


