using Game.Inventory;
using Game.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Body
{
    /// <summary>
    /// ��������, ������� ��������� �� ��������
    /// </summary>
    public class CreatureBody : MonoBehaviour
    {
        private Armor _helmet = null; // ����
        private Armor _chest = null; // ������
        private Armor _leggings = null; // ������
        private Armor _gloves = null; // ��������
        private Armor _boots = null; // �������
        private Armor _necklace = null; // ��������
        private Armor _ring = null; // ������

        private Dictionary<ArmorType, Armor> _creatureBodyDictionary = new Dictionary<ArmorType, Armor>(); // ������� � ����������
        public Dictionary<ArmorType, Armor> CreatureBodyDictionary { get => _creatureBodyDictionary; }

        public event Action<ChangeBodySlot> SetArmorEvent; // ��������� �������� � ���� ��� �����

        private CreatureInventory _creatureInventory = null;

        private void Awake()
        {
            CreateDictionary();
            _creatureInventory = GetComponent<CreatureInventory>();
            _creatureInventory.RemoveItemFromInventoryEvent += CheckItemIsDressed;
        }

        /// <summary>
        /// �������� �������
        /// </summary>
        private void CreateDictionary()
        {
            _creatureBodyDictionary.Add(ArmorType.Helmet, _helmet);
            _creatureBodyDictionary.Add(ArmorType.Chest, _chest);
            _creatureBodyDictionary.Add(ArmorType.Leggings, _leggings);
            _creatureBodyDictionary.Add(ArmorType.Gloves, _gloves);
            _creatureBodyDictionary.Add(ArmorType.Boots, _boots);
            _creatureBodyDictionary.Add(ArmorType.Necklace, _necklace);
            _creatureBodyDictionary.Add(ArmorType.Ring, _ring);
        }

        /// <summary>
        /// ��������� �������� � ����������� ����
        /// </summary>
        public void SetItemToSlot(Armor item, ArmorType armorType)
        {
            if (_creatureBodyDictionary.ContainsKey(armorType) && item.ArmorType == armorType)
            {
                if (_creatureBodyDictionary[armorType] == item) return;

                ChangeBodySlot changeBodySlot = new ChangeBodySlot(armorType, _creatureBodyDictionary[armorType], item);
                _creatureBodyDictionary[armorType] = item;
                SetArmorEvent?.Invoke(changeBodySlot);
            }
        }

        /// <summary>
        /// ������� ������� � ����
        /// </summary>
        public void RemoveArmor(ArmorType armorType)
        {
            if (_creatureBodyDictionary.ContainsKey(armorType))
            {
                ChangeBodySlot changeBodySlot = new ChangeBodySlot(armorType, _creatureBodyDictionary[armorType], null);
                _creatureBodyDictionary[armorType] = null;
                SetArmorEvent?.Invoke(changeBodySlot);
            }
        }

        /// <summary>
        /// ���������, ���� �� �������
        /// </summary>
        private void CheckItemIsDressed(Item item)
        {
            foreach (KeyValuePair<ArmorType, Armor> slot in _creatureBodyDictionary)
            {
                if (slot.Value == item)
                {
                    RemoveArmor(slot.Key);
                    return;
                }
            }
        }
    }
}
