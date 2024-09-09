using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Game.Body
{
    /// <summary>
    /// Иконка на канвасе с телом для доспехов
    /// </summary>
    public class PlayerBodyIconArmorUI : PlayerBodyIconUI
    {
        [Tooltip("Тип доспеха для данной иконки")]
        [SerializeField] private ArmorType _armorType;

        private new protected PlayerBodyIconType _bodyIconType = PlayerBodyIconType.Armor;
    }
}
