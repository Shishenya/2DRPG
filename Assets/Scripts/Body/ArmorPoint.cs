using Game.Body;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Parameters
{
    /// <summary>
    /// Считает очки брони на существе
    /// </summary>
    public class ArmorPoint : MonoBehaviour
    {
        private CreatureBody _creatureBody = null;
        private int _armorPoint = 0;

        public int armorPoint { get => _armorPoint; }

        private void Awake()
        {
            _creatureBody = GetComponent<CreatureBody>();
        }

        private void Start()
        {
            CalcArmorPoint();
        }

        private void OnEnable()
        {
            _creatureBody.SetArmorEvent += CalcArmorPoint;
        }

        private void OnDisable()
        {
            _creatureBody.SetArmorEvent -= CalcArmorPoint;
        }

        private void CalcArmorPoint(ArmorType type) =>
            CalcArmorPoint();

        /// <summary>
        /// Подсчет очков брони
        /// </summary>
        private void CalcArmorPoint()
        {
            foreach (KeyValuePair<ArmorType, Items.Armor> item in _creatureBody.CreatureBodyDictionary)
                _armorPoint += item.Value.ArmorValue;
        }
    }
}
