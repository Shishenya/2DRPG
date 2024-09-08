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
                    ВleedingEffect bleedingEffect = obj.AddComponent<ВleedingEffect>();
                    bleedingEffect?.SetBaseValue(values);
                    break;
                case EffectType.RecoveryFatigue: // Восстановление усталости
                    RecoveryFatigueEffect recoveryFatigueEffect = obj.AddComponent<RecoveryFatigueEffect>();
                    recoveryFatigueEffect.SetBaseValue(values);
                    break;
                case EffectType.RecoveryHealth: // Восстановление здоровья
                    RecoveryHealthEffect recoveryHealthEffect = obj.AddComponent<RecoveryHealthEffect>();
                    recoveryHealthEffect.SetBaseValue(values);
                    break;
            }
        }

        /// <summary>
        /// Получение описание эффектов
        /// </summary>
        public string GetDesriptionEffect(EffectParameters effectParameters)
        {
            switch (effectParameters.type)
            {
                case EffectType.ВleedingEffect:
                    return GetDesriptionВleedingEffect(effectParameters.values);
                case EffectType.RecoveryFatigue:
                    return GetDesriptionRecoveryFatigue(effectParameters.values);
                case EffectType.RecoveryHealth:
                    return GetDesriptionRecoveryHealth(effectParameters.values);
            }

            return string.Empty;

        }

        /// <summary>
        /// Возвращает описание всех эффектов
        /// </summary>
        public string GetDesriptionEffect(List<EffectParameters> effectsParameters)
        {
            string result = "";
            foreach (var item in effectsParameters)            
                result += GetDesriptionEffect(item);
            
            return result;
        }

        /// <summary>
        /// Возвращает описание эффекта кровотечения
        /// </summary>
        private string GetDesriptionВleedingEffect(string[] values)
        {
            string result = $"Кровотечение: (Урон за ход: {values[1]} в течении {values[0]} ходов)";
            return result;
        }

        /// <summary>
        /// Возвращает описание восстановления усталости
        /// </summary>
        private string GetDesriptionRecoveryFatigue(string[] values)
        {
            string result = $"Восстановление усталости: Восстановит {values[1]} энергии за 1 ход (всего {values[0]} ходов).";
            return result;
        }

        /// <summary>
        /// Возвращает описание эффекта восстановления жизней
        /// </summary>
        private string GetDesriptionRecoveryHealth(string[] values)
        {
            string result = $"Восстановление здоровья: При использовании восстановит {values[2]} жизней.<br>" +
                $"Затем каждый ход ({values[0]} ходов) будет восстанавливать {values[1]} жизней.<br>" +
                $"По завершению эффекта восстановить {values[3]} жизней";
            return result;
        }
    }
}
