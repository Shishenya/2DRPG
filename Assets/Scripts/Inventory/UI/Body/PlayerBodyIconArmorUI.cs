using Game.Body;
using Game.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Game.Body
{
    /// <summary>
    /// ������ �� ������� � ����� ��� ��������
    /// </summary>
    public class PlayerBodyIconArmorUI : PlayerBodyIconUI
    {
        [Tooltip("��� ������� ��� ������ ������")]
        [SerializeField] private ArmorType _armorType;

        public ArmorType ArmorType { get => _armorType; }

        private Armor _currentArmor = null;

        /// <summary>
        /// �������������
        /// </summary>
        public void Init(CreatureBody body)
        {
            _currentArmor = body.CreatureBodyDictionary[_armorType];
            _image.sprite = GameItemsStorage.Instance.GetItemSOByID(_currentArmor.Id).Sprite;
        }

        public void ReInit()
        {
            _currentArmor = null;
            _image.sprite = null;
        }

    }
}
