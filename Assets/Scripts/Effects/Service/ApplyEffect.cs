using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Effects
{
    /// <summary>
    /// Сервис наложние эффекта
    /// </summary>
    public class ApplyEffect : MonoBehaviour
    {
        private static ApplyEffect _applyEffect;
        public static ApplyEffect Instance { get => _applyEffect; }

        private void Awake()
        {
            _applyEffect = this;
            DontDestroyOnLoad(this);
        }

        /// <summary>
        /// Наложение эффекта на объект
        /// </summary>
        public void Apply(GameObject obj, EffectType effectType, string[] values)
        {
            switch (effectType)
            {
                case EffectType.ВleedingEffect: // Кровотечение
                    obj.AddComponent(typeof(ВleedingEffect));
                    obj.GetComponent<ВleedingEffect>()?.SetBaseValue(values);
                    break;
                case EffectType.RecoveryFatigue:
                    break;
                case EffectType.RecoveryHealth:
                    break;
            }
        }
    }
}
