using Game.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Body
{
    /// <summary>
    /// Предметы, которые находятся на существе
    /// </summary>
    public class CreatureBody : MonoBehaviour
    {
        private Armor _helmet = null; // шлем
        private Armor _chest = null; // доспех
        private Armor _leggings = null; // поножи
        private Armor _gloves = null; // перчатки
        private Armor _boots = null; // ботинки
        private Armor _necklace = null; // ожерелье
        private Armor _ring = null; // кольцо

        private Dictionary<ArmorType, Armor> _creatureBodyDictionary = new Dictionary<ArmorType, Armor>(); // Словарь с предметами
        public Dictionary<ArmorType, Armor> CreatureBodyDictionary { get => _creatureBodyDictionary; }

        public event Action<ArmorType> SetArmorEvent; // установка предмета в слот для брони

        private void Awake()
        {
            CreateDictionary();
        }

        /// <summary>
        /// Создание словаря
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
        /// Установка предмета в определнный слот
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
