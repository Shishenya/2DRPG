using UnityEngine;

namespace Game.Effects
{
    /// <summary>
    /// Ёффекты, которые накладываютс€ с определенным шансом
    /// </summary>
    public class EffectParametersByChance : EffectParameters
    {
        [Tooltip("Ўанс наложени€ эффекта")]
        [Range(0f, 100f)] public float chance;
    }
}
