using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Effects
{
    /// <summary>
    /// ������ �������� �������
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
        /// ��������� ������� �� ������
        /// </summary>
        public void Apply(GameObject obj, EffectType effectType, string[] values)
        {
            switch (effectType)
            {
                case EffectType.�leedingEffect: // ������������
                    �leedingEffect bleedingEffect = obj.AddComponent<�leedingEffect>();
                    bleedingEffect?.SetBaseValue(values);
                    break;
                case EffectType.RecoveryFatigue: // �������������� ���������
                    RecoveryFatigueEffect recoveryFatigueEffect = obj.AddComponent<RecoveryFatigueEffect>();
                    recoveryFatigueEffect.SetBaseValue(values);
                    break;
                case EffectType.RecoveryHealth: // �������������� ��������
                    RecoveryHealthEffect recoveryHealthEffect = obj.AddComponent<RecoveryHealthEffect>();
                    recoveryHealthEffect.SetBaseValue(values);
                    break;
            }
        }
    }
}
