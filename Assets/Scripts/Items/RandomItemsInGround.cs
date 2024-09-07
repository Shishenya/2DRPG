using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Items
{
 /// <summary>
 /// ��������� �������� �� �����
 /// </summary>
    public class RandomItemsInGround : ItemsInGround
    {
        [Tooltip("������ ��������� ��������� �� ���������")]
        [SerializeField] private List<RandomItemChance> _randomItems = new List<RandomItemChance>();

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            CreateItems();
            ChangeIcons();
        }

        /// <summary>
        /// �������� ���������
        /// </summary>
        private void CreateItems()
        {
            foreach (var randomItem in _randomItems)
            {
                if (SuccessfulChance(randomItem.chance)) // ���� ������ � ����
                {
                    Item item = GameItemsStorage.Instance.CreateItem(randomItem.idItem);
                    _items.Add(item);
                }
            }
        }

        /// <summary>
        /// �������� �� ���� �� �������� ��������
        /// </summary>
        private bool SuccessfulChance(float chance) => chance >= Random.Range(0, 100);
    }
}


