using Game.Parameters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Items
{
    /// <summary>
    /// Тип предмета - броня
    /// </summary>
    public class Armor : Item
    {
        private protected ArmorType _armorType; // тип брони
        private Сharacteristics _changeСharacteristics; // характеристики
        private int _armorValue; // очки брони

        public Armor(int id) : base(id)
        {
            SetConcrectParameters();
        }

        /// <summary>
        /// Получение конкретных параметров для брони
        /// </summary>
        public override void SetConcrectParameters()
        {
            ArmorItemSO itemArmor_SO = (ArmorItemSO)GameItemsStorage.Instance.GetItemSOByID(_id);
            _armorType = itemArmor_SO.ArmorType;
            _changeСharacteristics = itemArmor_SO.ChangeValue;
            _armorValue = itemArmor_SO.ArmorValue;
        }

        /// <summary>
        /// переопределенный метод с описанием предмета (еда)
        /// </summary>
        public override string GetDescription()
        {
            string result = base.GetDescription();
            result += $"";

            return result;
        }
    }
}
