using Game.Body;
using Game.Parameters;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI.Game.Body
{

    /// <summary>
    /// ������ � ��������, �� ������� �������� �������� �� ������
    /// </summary>
    public class PlayerBodyCanvas : MonoBehaviour
    {
        [Tooltip("������ � �����")]
        [SerializeField] private GameObject _background = null;

        [Tooltip("���� ������")]
        [SerializeField] private CreatureBody _body;

        [Tooltip("���� �����")]
        [SerializeField] private ArmorPoint _armorPoint = null;

        [Tooltip("��������� ���� ��� ����� �����")]
        [SerializeField] private TMP_Text _armorPointTMP = null;

        [Tooltip("����� ��� �����")]
        [SerializeField] private List<PlayerBodyIconArmorUI> _slots = new List<PlayerBodyIconArmorUI>();

        private Dictionary<ArmorType, PlayerBodyIconArmorUI> _slotsDictionary = new Dictionary<ArmorType, PlayerBodyIconArmorUI>();

        private readonly KeyCode _bodyKey = KeyCode.Tab;
        private readonly string _armorPointPrefix = "���� �����: ";

        private void Awake()
        {
            CreateDictionary();
        }

        private void Update()
        {
            if (Input.GetKeyDown(_bodyKey))
                LoadBody();
        }

        private void OnEnable()
        {
            _body.SetArmorEvent += ChangeIconOnSlot;
            _armorPoint.ChangeArmorPointEvent += UpdateArmorPointTMP;
        }

        private void CreateDictionary()
        {
            foreach (var item in _slots)            
                _slotsDictionary.Add(item.ArmorType, item);            
        }

        /// <summary>
        /// �������� � �������� ������ � ����� 
        /// </summary>
        private void LoadBody()
        {
            _background.SetActive(!_background.activeInHierarchy);
            //if (_background.activeInHierarchy == false) _desciptionPanel.gameObject.SetActive(false);
        }

        /// <summary>
        /// ��������� ������ � �����
        /// </summary>
        private void ChangeIconOnSlot(ChangeBodySlot changeBodySlot)
        {
            if (_slotsDictionary.ContainsKey(changeBodySlot.armorType))            
                _slotsDictionary[changeBodySlot.armorType].Init(_body);            
        }

        /// <summary>
        /// ��������� ���������� ����� �����
        /// </summary>
        private void UpdateArmorPointTMP()
        {
            _armorPointTMP.text = $"{_armorPointPrefix}{_armorPoint.armorPoint}";
        }
    }
}
