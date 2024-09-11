using Game.Body;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Game.Body
{

    /// <summary>
    /// Работа с канвасом, на котором рисуются предметы на игроке
    /// </summary>
    public class PlayerBodyCanvas : MonoBehaviour
    {
        [Tooltip("Панель с телом")]
        [SerializeField] private GameObject _background = null;

        [Tooltip("Тело игрока")]
        [SerializeField] private CreatureBody _body;

        [Tooltip("Слоты для брони")]
        [SerializeField] private List<PlayerBodyIconArmorUI> _slots = new List<PlayerBodyIconArmorUI>();

        private Dictionary<ArmorType, PlayerBodyIconArmorUI> _slotsDictionary = new Dictionary<ArmorType, PlayerBodyIconArmorUI>();

        private readonly KeyCode _bodyKey = KeyCode.Tab;

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
        }

        private void CreateDictionary()
        {
            foreach (var item in _slots)            
                _slotsDictionary.Add(item.ArmorType, item);            
        }

        /// <summary>
        /// Загрузка и выгрузка панели с телом 
        /// </summary>
        private void LoadBody()
        {
            _background.SetActive(!_background.activeInHierarchy);
            //if (_background.activeInHierarchy == false) _desciptionPanel.gameObject.SetActive(false);
        }

        /// <summary>
        /// Изменение иконке в слоте
        /// </summary>
        private void ChangeIconOnSlot(ArmorType armorType)
        {
            if (_slotsDictionary.ContainsKey(armorType))            
                _slotsDictionary[armorType].Init(_body);            
        }
    }
}
