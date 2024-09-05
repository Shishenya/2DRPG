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
        private protected Step.Step _step; // ���, �� �������� ������ ������
        private protected EffectType _effectType; // ��� �������

        private protected int _movesEffect = 0; // ������������ �������
        private protected int _currentMoves = 0; // ������� ����� ������

        private protected EffectInGame_SO _effectInGame_SO = null; // �������� �������

        private protected CreatureEffects _creatureEffects = null;

        public int MovesLeft { get=> _movesEffect - _currentMoves; } // �������� �����

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
        /// ��������� ����������� ����������
        /// </summary>
        public virtual void SetBaseValue(string[] values) { }

        public virtual void ExecuteEffect() { } // ���������� ������� � ����� ����
        public virtual void DoEffectAfterStart() { } // ���������� ������� ��� ��������� �������
        public virtual void DoEffectAfterCompleted() { } // ���������� ������� ����� ���������
        public virtual string GetDescription() { return string.Empty; } // �������� �������

    }
}
