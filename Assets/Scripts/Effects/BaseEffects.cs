using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Game.Step;

namespace Game.Effects
{

    /// <summary>
    /// ������� ����� ��� ��������
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

        public virtual void ExecuteEffect() { } // ���������� ������� � ����� ����
        public virtual void DoEffectAfterStart() { } // ���������� ������� ��� ��������� �������
        public virtual void DoEffectAfterCompleted() { } // ���������� ������� ����� ���������
        public virtual string GetDescription() { return string.Empty; } // �������� �������

    }
}
