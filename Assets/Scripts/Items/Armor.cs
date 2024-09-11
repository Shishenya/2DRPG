using Game.Body;
using Game.Parameters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Items
{
    /// <summary>
    /// ��� �������� - �����
    /// </summary>
    public class Armor : Item, IWearable
    {
        private protected ArmorType _armorType; // ��� �����
        private �haracteristics _change�haracteristics; // ��������������
        private int _armorValue; // ���� �����

        public ArmorType ArmorType { get => _armorType; }
        public �haracteristics Change�haracteristics { get => _change�haracteristics; }
        public int ArmorValue { get => _armorValue; }

        public Armor(int id) : base(id)
        {
            SetConcrectParameters();
        }

        /// <summary>
        /// ��������� ���������� ���������� ��� �����
        /// </summary>
        public override void SetConcrectParameters()
        {
            ArmorItemSO itemArmor_SO = (ArmorItemSO)GameItemsStorage.Instance.GetItemSOByID(_id);
            _armorType = itemArmor_SO.ArmorType;
            _change�haracteristics = itemArmor_SO.ChangeValue;
            _armorValue = itemArmor_SO.ArmorValue;
        }

        /// <summary>
        /// ���������������� ����� � ��������� �������� (���)
        /// </summary>
        public override string GetDescription()
        {
            string result = base.GetDescription();
            result += $"<br>���� �����: <b>{_armorValue}</b><br>" +
                $"�������� ��������������:<br>{_change�haracteristics.GetDescription()}";

            return result;
        }

        /// <summary>
        /// ���������� ��� ��������
        /// </summary>
        public override string GetTypeItem()
        {
            switch (_armorType)
            {
                case ArmorType.Helmet:
                    return "����� (����)";
                case ArmorType.Chest:
                    return "����� (�������)";
                case ArmorType.Leggings:
                    return "����� (������)";
                case ArmorType.Gloves:
                    return "����� (��������)";
                case ArmorType.Boots:
                    return "����� (�������)";
                case ArmorType.Ring:
                    return "���������� (������)";
                case ArmorType.Necklace:
                    return "���������� (��������)";
            }

            return base.GetTypeItem();
        }

        /// <summary>
        /// ������������� �������� - ������� ��� �� ����
        /// </summary>
        public void Wearable(GameObject target)
        {
            CreatureBody body = target.GetComponent<CreatureBody>();
            body?.SetItemToSlot(this, _armorType);
        }
    }
}
