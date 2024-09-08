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

        /// <summary>
        /// ��������� �������� ��������
        /// </summary>
        public string GetDesriptionEffect(EffectParameters effectParameters)
        {
            switch (effectParameters.type)
            {
                case EffectType.�leedingEffect:
                    return GetDesription�leedingEffect(effectParameters.values);
                case EffectType.RecoveryFatigue:
                    return GetDesriptionRecoveryFatigue(effectParameters.values);
                case EffectType.RecoveryHealth:
                    return GetDesriptionRecoveryHealth(effectParameters.values);
            }

            return string.Empty;

        }

        /// <summary>
        /// ���������� �������� ���� ��������
        /// </summary>
        public string GetDesriptionEffect(List<EffectParameters> effectsParameters)
        {
            string result = "";
            foreach (var item in effectsParameters)            
                result += GetDesriptionEffect(item);
            
            return result;
        }

        /// <summary>
        /// ���������� �������� ������� ������������
        /// </summary>
        private string GetDesription�leedingEffect(string[] values)
        {
            string result = $"������������: (���� �� ���: {values[1]} � ������� {values[0]} �����)";
            return result;
        }

        /// <summary>
        /// ���������� �������� �������������� ���������
        /// </summary>
        private string GetDesriptionRecoveryFatigue(string[] values)
        {
            string result = $"�������������� ���������: ����������� {values[1]} ������� �� 1 ��� (����� {values[0]} �����).";
            return result;
        }

        /// <summary>
        /// ���������� �������� ������� �������������� ������
        /// </summary>
        private string GetDesriptionRecoveryHealth(string[] values)
        {
            string result = $"�������������� ��������: ��� ������������� ����������� {values[2]} ������.<br>" +
                $"����� ������ ��� ({values[0]} �����) ����� ��������������� {values[1]} ������.<br>" +
                $"�� ���������� ������� ������������ {values[3]} ������";
            return result;
        }
    }
}
