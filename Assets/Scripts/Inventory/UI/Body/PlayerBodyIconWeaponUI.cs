using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Game.Body
{
    /// <summary>
    /// Иконка на канвасе с телом для оружия
    /// </summary>
    public class PlayerBodyIconWeaponUI : PlayerBodyIconUI
    {
        [Tooltip("Тип оружия для данной иконки")]
        [SerializeField] private WeaponType _weaponType;

        //private new protected PlayerBodyIconType _bodyIconType = PlayerBodyIconType.Weapon;
    }
}
