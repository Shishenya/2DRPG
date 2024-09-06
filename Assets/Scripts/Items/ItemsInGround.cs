using Player.Move;
using System;
using System.Collections.Generic;
using UI.Game.Items;
using UnityEngine;

namespace Game.Items
{
    /// <summary>
    /// �������� �� �����
    /// </summary>
    public class ItemsInGround : MonoBehaviour
    {
        [Tooltip("ID ���������, ������� ����� �� �����")]
        [SerializeField] private List<int> _itemsID = new List<int>();

        private List<Item> _items = new List<Item>();  // ���� ��������

        public List<Item> Items { get => _items; }

        public event Action<Item> RemoveItemEvent; // ����� �������� ��������
        public event Action IsEmptyItemsEvent; // �����, ����� ����������� �������� �� �����

        private SpriteRenderer _spriteRenderer = null;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            CreateItems();
            ChangeIcons();
        }

        private void Start() { }

        /// <summary>
        /// �������� ��������� ��� ������������
        /// </summary>
        private void CreateItems()
        {
            foreach (var id in _itemsID)
            {
                Item item = GameItemsStorage.Instance.CreateItem(id);
                _items.Add(item);
            }
        }

        /// <summary>
        /// ��������� ������ ��������� �� �����
        /// </summary>
        private void ChangeIcons()
        {
            if (_items.Count > 1)
                _spriteRenderer.sprite = GameItemsStorage.Instance.DefaultSprite;
            else if (_items.Count == 1)
                _spriteRenderer.sprite = GameItemsStorage.Instance.GetItemSOByID(_items[0].Id).Sprite;
            else if (_items.Count == 0) _spriteRenderer.sprite = null;
        }

        /// <summary>
        /// �������� ��������
        /// </summary>
        public void RemoveItem(Item item)
        {
            _items.Remove(item);
            ChangeIcons();
            RemoveItemEvent?.Invoke(item);

            if (_items.Count == 0)
            {
                IsEmptyItemsEvent?.Invoke();
                Destroy(this.gameObject);
            }

        }

        /// <summary>
        /// ����� � �������� � ����������
        /// </summary>
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!IsPlayer(collision)) return;
            ItemsInGroundCanvas.Instance.Init(this);
        }

        /// <summary>
        /// ����� �� ���������� � ����������
        /// </summary>
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (!IsPlayer(collision)) return;
            ItemsInGroundCanvas.Instance.ReInit();
        }

        /// <summary>
        /// �������� �� ������
        /// </summary>
        private bool IsPlayer(Collider2D collision) => collision.TryGetComponent<PlayerMove>(out PlayerMove move);

    }
}
