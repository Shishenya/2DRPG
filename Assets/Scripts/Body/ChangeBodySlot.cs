using System;
using Game.Items;


namespace Game.Body
{
    /// <summary>
    /// Изменение слота предмета
    /// </summary>
    public class ChangeBodySlot : EventArgs
    {
        public ArmorType armorType; // тип брони
        public Armor prevItem; // предыдущий предмет в слоте
        public Armor nowItem; // текущий предмет в слоте

        public ChangeBodySlot(ArmorType armorType, Armor prevItem, Armor nowItem)
        {
            this.armorType = armorType;
            this.prevItem = prevItem;
            this.nowItem = nowItem;
        }
    }
}
