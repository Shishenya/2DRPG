using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Game.Body
{
    /// <summary>
    /// ������ �� ������� � ����� ��� ������
    /// </summary>
    public class PlayerBodyIconWeaponUI : PlayerBodyIconUI
    {
        [Tooltip("��� ������ ��� ������ ������")]
        [SerializeField] private WeaponType _weaponType;

        //private new protected PlayerBodyIconType _bodyIconType = PlayerBodyIconType.Weapon;
    }
}
