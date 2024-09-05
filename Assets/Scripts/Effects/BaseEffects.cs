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
        private protected Step.Step _step; // Шаг, по которому делаем эффект
        private protected EffectType _effectType; // тип эффекта

        private protected int _movesEffect = 0; // длительность эффекта
        private protected int _currentMoves = 0; // сколько ходов прошло

        private protected EffectInGame_SO _effectInGame_SO = null; // описание эффекта

        private protected CreatureEffects _creatureEffects = null;

        public int MovesLeft { get=> _movesEffect - _currentMoves; } // Осталось ходов

        public EffectType EffectType { get=> _effectType;  }

        public virtual void Awake()
        {
            _step = GetComponent<Step.Step>();
            _creatureEffects = GetComponent<CreatureEffects>();
        }

        public void Start()
        {
            _effectInGame_SO = GameEffectsStorage.Instance.GetEffectByType(_effectType);
        }

        /// <summary>
        /// Установка стандартных параметров
        /// </summary>
        public virtual void SetBaseValue(string[] values) { }

        public virtual void ExecuteEffect() { } // выполнение эффекта в конце хода
        public virtual void DoEffectAfterStart() { } // выполнение эффекта при получении эффекта
        public virtual void DoEffectAfterCompleted() { } // выполнение эффекта после окончания
        public virtual string GetDescription() { return string.Empty; } // описание эффекта

    }
}
