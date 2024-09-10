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

        public event Action<ArmorType> SetArmorEvent; // ��������� �������� � ���� ��� �����

        private void Awake()
        {
            CreateDictionary();
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
                _creatureBodyDictionary[armorType] = item;
                SetArmorEvent?.Invoke(armorType);
            }
        }
    }
}
