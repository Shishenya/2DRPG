using UnityEngine;

/// <summary>
/// Наложение эффекта "восстановление усталости"
/// </summary>
public class OverlayRecoveryFatigueEffect: OverlayEffect
{
    [Tooltip("Количество ходов восстановления")]
    [SerializeField] private int _moves;

    [Tooltip("Количество которое восстанавливается")]
    [SerializeField] private int _value;

    [Tooltip("Сколько выностивости восстановить при получении эффекта")]
    [SerializeField] private float _startValue;

    /// <summary>
    /// Наложение эффекта восстановления
    /// </summary>
    public override void Overlay(GameObject go)
    {
        if (go.TryGetComponent<Fatigue>(out Fatigue fatigue) && go.TryGetComponent<CreatureEffects>(out CreatureEffects creatureEffects))
        {
            RecoveryFatigueEffect recoveryFatigueEffect = new RecoveryFatigueEffect(_moves, 0, fatigue, _value, _startValue);
            creatureEffects.AddEffect(recoveryFatigueEffect);
        }
    }
}