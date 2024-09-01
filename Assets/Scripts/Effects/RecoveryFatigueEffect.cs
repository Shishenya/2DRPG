/// <summary>
/// Эффект восстановление усталости
/// </summary>
public class RecoveryFatigueEffect : BaseEffects
{

    private protected Fatigue _fatigue = null;
    private protected float _valueIncrement = 0f;
    private protected float _startIncrement = 0f;

    public RecoveryFatigueEffect(int durationEffect, int movesLeft, Fatigue fatigue, int value, float startIncrement) : base(durationEffect, movesLeft)
    {
        _effectType = EffectType.RecoveryFatigue; // восстановление усталости
        _fatigue = fatigue;
        _valueIncrement = value;
        _startIncrement = startIncrement;

        _effectInGame_SO = GameEffectsStorage.Instance.GetEffectByType(_effectType);
    }

    /// <summary>
    /// Выполнение эффекта восстановления усталости
    /// </summary>
    public override void DoEffect()
    {
        _fatigue.ChangeFatigue(_valueIncrement);
        base.DoEffect();
    }

    /// <summary>
    /// Выполнение эффекта при подборе
    /// </summary>
    public override void DoEffectAfterStart()
    {
        _fatigue.ChangeFatigue(_startIncrement);
    }

    /// <summary>
    /// Возвращает описание эффекта
    /// </summary>
    public override string GetDescription()
    {
        string description = $"<b>{_effectInGame_SO.Title}</b>.<br>" +
            $"{_effectInGame_SO.Description}<br>" +
            $"Восстанавливают за ход: {_valueIncrement}.<br>" +
            $"Осталось ходов: {MovesLeft} ";
        return description;
    }
}