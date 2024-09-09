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

        private new protected PlayerBodyIconType _bodyIconType = PlayerBodyIconType.Armor;
    }
}
