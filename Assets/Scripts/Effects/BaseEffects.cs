using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// ������� ����� ��� ��������
/// </summary>
[System.Serializable]
public class BaseEffects
{
    private protected int _durationEffect = 0; // ����������������� �������
    private protected int _movesLeft = 0; // �������� ����� �� ����� �������

    public event Action<BaseEffects> EffectCompletedEvent; // ������ �������� ���� ��������

    private bool _isCompleted = false;
    public bool IsCompleted { get => _isCompleted; }

    public BaseEffects(int durationEffect, int movesLeft)
    {
        _durationEffect = durationEffect;
        _movesLeft = movesLeft;
    }

    /// <summary>
    /// ���������� ���������� �����, ����� ������ ���������
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
    /// ����������� ����� ���������� �������
    /// </summary>
    public virtual void DoEffect()
    {
        IncrementMoveEffect();
    }


}
