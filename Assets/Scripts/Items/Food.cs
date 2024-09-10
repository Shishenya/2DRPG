using Game.Effects;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Items
{
    /// <summary>
    /// Тип предмета - еда
    /// </summary>
    [System.Serializable]
    public class Food : Item, IUsebaleItem
    {
        private List<EffectParameters> _effects;

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
            _effects = itemFood_SO.Effects;
        }

        /// <summary>
        /// переопределенный метод с описанием предмета (еда)
        /// </summary>
        public override string GetDescription()
        {
            string result = base.GetDescription();
            result += $"<br>"+
                $"<b>Накладываются эффекты:</b><br>{ApplyEffect.Instance.GetDesriptionEffect(_effects)}";

            return result;
        }

        /// <summary>
        /// Исопльзование еды - накладывание эффетов
        /// </summary>
        public void Use(GameObject target)
        {
            Apply(target);
        }

        /// <summary>
        /// Наложение эффектов
        /// </summary>
        public void Apply(GameObject target)
        {
            foreach (var item in _effects)            
                ApplyEffect.Instance.Apply(target, item.type, item.values);            
        }

        /// <summary>
        /// Возвращает тип предмета
        /// </summary>
        public override string GetTypeItem()
        {
            return "Еда";
        }
    }
}
