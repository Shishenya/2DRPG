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
                    obj.AddComponent(typeof(�leedingEffect));
                    obj.GetComponent<�leedingEffect>()?.SetBaseValue(values);
                    break;
                case EffectType.RecoveryFatigue:
                    break;
                case EffectType.RecoveryHealth:
                    break;
            }
        }
    }
}
