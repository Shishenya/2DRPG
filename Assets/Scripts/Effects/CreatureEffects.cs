using System.Collections.Generic;
using UnityEngine;
using System;

namespace Game.Effects
{
    /// <summary>
    /// Эффекты, наложенные на определенное существо
    /// </summary>
    public class CreatureEffects : MonoBehaviour
    {

        private List<BaseEffects> _effects = new List<BaseEffects>();

        public event Action AddEffectEvent;
        public event Action RemoveEffectEvent;

        private void Start() { }

        /// <summary>
        /// Добавление эффекта
        /// </summary>
        public void AddEffect(BaseEffects effect)
        {
            _effects.Add(effect);
            AddEffectEvent?.Invoke();
        }

        /// <summary>
        /// Удаление эффекта
        /// </summary>
        public void RemoveEffect(BaseEffects effect)
        {
            _effects.Remove(effect);
            RemoveEffectEvent?.Invoke();
        }
 
    }
}
