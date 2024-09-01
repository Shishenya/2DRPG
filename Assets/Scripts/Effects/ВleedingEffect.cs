using UnityEngine;

/// <summary>
/// Эффект кровотечения
/// </summary>
[System.Serializable]
public class ВleedingEffect: BaseEffects
{

    private protected Health _health; // На какое здоровье он будет влиять
    private protected int _damage;

    public ВleedingEffect(int durationEffect, int movesLeft, Health health, int damage) : base (durationEffect, movesLeft)
    {
        _effectType = EffectType.ВleedingEffect; // устанавливаем тип эффекта "Кровотечение"
        _health = health;
        _damage = damage;

        _effectInGame_SO = GameEffectsStorage.Instance.GetEffectByType(_effectType);
    }

    /// <summary>
    /// Выполнение эффекта кровотечения
    /// </summary>
    public override void DoEffect() {
        Debug.Log("Выполняю эффект кровотечения");
        _health.ChangeHealth(_damage);
        base.DoEffect();
    }

    /// <summary>
    /// После завержения выполнения эффекта кровотечения
    /// </summary>
    public override void DoCompleteEffect()
    {
         // Ничего не происходит, но тут я еще подумаю
    }

    /// <summary>
    /// Возвращает описание эффекта
    /// </summary>
    public override string GetDescription()
    {
        string description = $"<b>{_effectInGame_SO.Title}</b>.<br>" +
            $"{_effectInGame_SO.Description}<br>" +
            $"Урон за ход: {-1*_damage}<br>" +
            $"Осталось ходов: {MovesLeft}";
        return description;
    }
}