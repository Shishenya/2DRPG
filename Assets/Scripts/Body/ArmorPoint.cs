using Game.Body;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Parameters
{
    /// <summary>
    /// —читает очки брони на существе
    /// </summary>
    public class ArmorPoint : MonoBehaviour
    {
        private CreatureBody _creatureBody = null;
        private int _armorPoint = 0;

        public int armorPoint { get => _armorPoint; }

        public event Action ChangeArmorPointEvent;

        private void Awake()
        {
            _creatureBody = GetComponent<CreatureBody>();
        }

        private void Start()
        {

        }

        private void OnEnable()
        {
            _creatureBody.SetArmorEvent += CalcArmorPoint;
        }

        private void OnDisable()
        {
            _creatureBody.SetArmorEvent -= CalcArmorPoint;
        }

        /// <summary>
        /// ѕересчет очков защиты
        /// </summary>
        private void CalcArmorPoint(ChangeBodySlot changeBodySlot)
        {
            //CalcArmorPoint();
            if (_creatureBody.CreatureBodyDictionary.ContainsKey(changeBodySlot.armorType))
            {
                if (changeBodySlot.prevItem != null)
                    _armorPoint -= changeBodySlot.prevItem.ArmorValue;

                _armorPoint += changeBodySlot.nowItem.ArmorValue;
                ChangeArmorPointEvent?.Invoke();
            }
        }


    }
}
