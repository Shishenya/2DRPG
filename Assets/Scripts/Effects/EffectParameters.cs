using UnityEngine;


namespace Game.Effects
{
    /// <summary>
    /// ��������� ��� �������
    /// </summary>
    [System.Serializable]
    public class EffectParameters
    {
        [Tooltip("��� �������")]
        public EffectType type;
        [Tooltip("����� ��������� �����������")]
        public string[] values;
    } 

}
