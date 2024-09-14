using System;
using Game.Items;


namespace Game.Body
{
    /// <summary>
    /// ��������� ����� ��������
    /// </summary>
    public class ChangeBodySlot : EventArgs
    {
        public ArmorType armorType; // ��� �����
        public Armor prevItem; // ���������� ������� � �����
        public Armor nowItem; // ������� ������� � �����

        public ChangeBodySlot(ArmorType armorType, Armor prevItem, Armor nowItem)
        {
            this.armorType = armorType;
            this.prevItem = prevItem;
            this.nowItem = nowItem;
        }
    }
}
