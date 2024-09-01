using UnityEngine;

/// <summary>
/// Наложение эффекта кровотечения
/// </summary>
public class OverlayВleedingEffect : OverlayEffect
{
    [Tooltip("Количество ходов кровотечения")]
    [SerializeField] private int _moves;

    [Tooltip("Урон, наноссимый кровотечением")]
    [SerializeField] private int _damage;

    /// <summary>
    /// Наложение эффекта кровотечения
    /// </summary>
    public override void Overlay(GameObject go)
    {
        if (go.TryGetComponent<Health>(out Health health) && go.TryGetComponent<CreatureEffects>(out CreatureEffects creatureEffects))
        {
            ВleedingEffect вleedingEffect = new ВleedingEffect(_moves, 0, health, _damage);
            creatureEffects.AddEffect(вleedingEffect);
        }
    }
}
