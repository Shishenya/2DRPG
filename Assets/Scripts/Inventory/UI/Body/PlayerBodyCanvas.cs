using Game.Body;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Game.Body
{

    /// <summary>
    /// ������ � ��������, �� ������� �������� �������� �� ������
    /// </summary>
    public class PlayerBodyCanvas : MonoBehaviour
    {
        [Tooltip("���� ������")]
        [SerializeField] private CreatureBody _body;

        [Tooltip("����� ��� �����")]
        [SerializeField] private List<PlayerBodyIconArmorUI> _slots = new List<PlayerBodyIconArmorUI>();

        private Dictionary<ArmorType, PlayerBodyIconArmorUI> _slotsDictionary = new Dictionary<ArmorType, PlayerBodyIconArmorUI>();

        private void Awake()
        {
            CreateDictionary();
        }

        private void OnEnable()
        {
            _body.SetArmorEvent += ChangeIconOnSlot;            
        }

        private void CreateDictionary()
        {
            foreach (var item in _slots)            
                _slotsDictionary.Add(item.ArmorType, item);            
        }

        /// <summary>
        /// ��������� ������ � �����
        /// </summary>
        private void ChangeIconOnSlot(ArmorType armorType)
        {
            if (_slotsDictionary.ContainsKey(armorType))            
                _slotsDictionary[armorType].Init(_body);            
        }
    }
}
