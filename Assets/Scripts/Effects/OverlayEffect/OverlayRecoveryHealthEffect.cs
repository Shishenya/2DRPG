using UnityEngine;

/// <summary>
/// Наложение эффекта восстановления здоровья
/// </summary>
public class OverlayRecoveryHealthEffect : OverlayEffect
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
        if (go.TryGetComponent<Health>(out Health health) && go.TryGetComponent<CreatureEffects>(out CreatureEffects creatureEffects))
        {
            RecoveryHealthEffect recoveryHealthEffect = new RecoveryHealthEffect(_moves, 0, health, _value, _startValue);
            creatureEffects.AddEffect(recoveryHealthEffect);
        }
    }
}