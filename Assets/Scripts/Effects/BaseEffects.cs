using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Базовый класс для эффектов
/// </summary>
[System.Serializable]
public class BaseEffects
{
    private protected int _durationEffect = 0; // Продолжительность эффекта
    private protected int _movesLeft = 0; // Осталось ходов до конца эффекта

    public event Action<BaseEffects> EffectCompletedEvent; // Эффект завершил свое действие

    private bool _isCompleted = false;
    public bool IsCompleted { get => _isCompleted; }

    public BaseEffects(int durationEffect, int movesLeft)
    {
        _durationEffect = durationEffect;
        _movesLeft = movesLeft;
    }

    /// <summary>
    /// Увеличение количества ходов, когда эффект действует
    /// </summary>
    public void IncrementMoveEffect()
    {
        _movesLeft++;
        if (_movesLeft == _durationEffect)
        {
            _isCompleted = true;
            EffectCompletedEvent?.Invoke(this);
        }
    }

    /// <summary>
    /// Виртуальный метод выполнения эффекта
    /// </summary>
    public virtual void DoEffect()
    {
        IncrementMoveEffect();
    }


}
