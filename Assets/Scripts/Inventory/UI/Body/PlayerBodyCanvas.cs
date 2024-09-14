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
    /// Работа с канвасом, на котором рисуются предметы на игроке
    /// </summary>
    public class PlayerBodyCanvas : MonoBehaviour
    {
        [Tooltip("Панель с телом")]
        [SerializeField] private GameObject _background = null;

        [Tooltip("Тело игрока")]
        [SerializeField] private CreatureBody _body;

        [Tooltip("Очки брони")]
        [SerializeField] private ArmorPoint _armorPoint = null;

        [Tooltip("Текстовое поле для очков брони")]
        [SerializeField] private TMP_Text _armorPointTMP = null;

        [Tooltip("Слоты для брони")]
        [SerializeField] private List<PlayerBodyIconArmorUI> _slots = new List<PlayerBodyIconArmorUI>();

        private Dictionary<ArmorType, PlayerBodyIconArmorUI> _slotsDictionary = new Dictionary<ArmorType, PlayerBodyIconArmorUI>();

        private readonly KeyCode _bodyKey = KeyCode.Tab;
        private readonly string _armorPointPrefix = "Очки брони: ";

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
        private void ChangeIconOnSlot(ChangeBodySlot changeBodySlot)
        {
            if (_slotsDictionary.ContainsKey(changeBodySlot.armorType))            
                _slotsDictionary[changeBodySlot.armorType].Init(_body);            
        }

        /// <summary>
        /// Изменение количества очков брони
        /// </summary>
        private void UpdateArmorPointTMP()
        {
            _armorPointTMP.text = $"{_armorPointPrefix}{_armorPoint.armorPoint}";
        }
    }
}
