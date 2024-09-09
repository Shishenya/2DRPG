using UnityEngine;

namespace Game.Effects
{
    /// <summary>
    /// �������, ������� ������������� � ������������ ������
    /// </summary>
    public class EffectParametersByChance : EffectParameters
    {
        [Tooltip("���� ��������� �������")]
        [Range(0f, 100f)] public float chance;
    }
}
