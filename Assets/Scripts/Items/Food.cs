using System.Collections.Generic;
using UnityEngine;

namespace Game.Items
{
    /// <summary>
    /// Тип предмета - еда
    /// </summary>
    [System.Serializable]
    public class Food : Item
    {

        public Food(int id) : base(id)
        {
            SetConcrectParameters();
        }

        /// <summary>
        /// Добавление конкретных параметров для еды
        /// </summary>
        public override void SetConcrectParameters()
        {
            ItemFood_SO itemFood_SO = (ItemFood_SO)GameItemsStorage.Instance.GetItemSOByID(_id);            
        }

        /// <summary>
        /// переопределенный метод с описанием предмета (еда)
        /// </summary>
        public override string GetDescription()
        {
            string result = base.GetDescription();
            result += $"<br>" +
                $"Накладываются эффекты: <br>";

            return result;
        }
    }
}
