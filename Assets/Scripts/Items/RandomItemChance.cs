using UnityEngine;

namespace Game.Items
{
    /// <summary>
    /// Шанс для рандомного предмета
    /// </summary>
    [System.Serializable]
    public class RandomItemChance
    {
        [Tooltip("ID предмета")]
        public int idItem;
        [Tooltip("Шанс выпадение данного предмета"), Range(0f, 100f)]
        public float chance;
    }
}
