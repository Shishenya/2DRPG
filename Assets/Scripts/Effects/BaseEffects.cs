using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Game.Step;

namespace Game.Effects
{

    /// <summary>
    /// Базовый класс для эффектов
    /// </summary>

    public class BaseEffects : MonoBehaviour
    {
        private protected Step.Step _step;
        private protected EffectType _effectType;

        public EffectType EffectType { get=> _effectType;  }

        public virtual void Awake()
        {
            _step = GetComponent<Step.Step>();
        }

        public virtual void ExecuteEffect() { } // выполнение эффекта в конце хода
        public virtual void DoEffectAfterStart() { } // выполнение эффекта при получении эффекта
        public virtual void DoEffectAfterCompleted() { } // выполнение эффекта после окончания
        public virtual string GetDescription() { return string.Empty; } // описание эффекта

    }
}
