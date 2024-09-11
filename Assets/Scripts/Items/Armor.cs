using Game.Body;
using Game.Parameters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Items
{
    /// <summary>
    /// Тип предмета - броня
    /// </summary>
    public class Armor : Item, IWearable
    {
        private protected ArmorType _armorType; // тип брони
        private Сharacteristics _changeСharacteristics; // характеристики
        private int _armorValue; // очки брони

        public ArmorType ArmorType { get => _armorType; }
        public Сharacteristics ChangeСharacteristics { get => _changeСharacteristics; }
        public int ArmorValue { get => _armorValue; }

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
            result += $"<br>Очки брони: <b>{_armorValue}</b><br>" +
                $"Изменяет характеристики:<br>{_changeСharacteristics.GetDescription()}";

            return result;
        }

        /// <summary>
        /// Возвращает тип предмета
        /// </summary>
        public override string GetTypeItem()
        {
            switch (_armorType)
            {
                case ArmorType.Helmet:
                    return "Броня (шлем)";
                case ArmorType.Chest:
                    return "Броня (доспехи)";
                case ArmorType.Leggings:
                    return "Броня (поножи)";
                case ArmorType.Gloves:
                    return "Броня (перчатки)";
                case ArmorType.Boots:
                    return "Броня (ботинки)";
                case ArmorType.Ring:
                    return "Аксессуары (кольцо)";
                case ArmorType.Necklace:
                    return "Аксессуары (ожерелье)";
            }

            return base.GetTypeItem();
        }

        /// <summary>
        /// Использование предмета - одевает его на себя
        /// </summary>
        public void Wearable(GameObject target)
        {
            CreatureBody body = target.GetComponent<CreatureBody>();
            body?.SetItemToSlot(this, _armorType);
        }
    }
}
