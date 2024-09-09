using UnityEngine;


namespace Game.Effects
{
    /// <summary>
    /// Параметры для эффекта
    /// </summary>
    [System.Serializable]
    public class EffectParameters
    {
        [Tooltip("Тип эффекта")]
        public EffectType type;
        [Tooltip("Какие параметры накладывает")]
        public string[] values;
    } 

}
