using UnityEngine;

namespace Game.Items
{
    /// <summary>
    /// ���� ��� ���������� ��������
    /// </summary>
    [System.Serializable]
    public class RandomItemChance
    {
        [Tooltip("ID ��������")]
        public int idItem;
        [Tooltip("���� ��������� ������� ��������"), Range(0f, 100f)]
        public float chance;
    }
}
