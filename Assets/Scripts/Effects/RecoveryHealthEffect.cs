public class RecoveryHealthEffect: BaseEffects
{
    private protected Health _health; // На какое здоровье он будет влиять
    private protected int _recoveryValue;
    private protected float _recoverуHealthAfterStart = 0;

    public RecoveryHealthEffect(int durationEffect, int movesLeft, Health health, int recoveryValue, float recoverуHealthAfterStart) : base(durationEffect, movesLeft) 
    {
        _effectType = EffectType.RecoveryHealth; // устанавливаем тип эффекта "восстановление здоровья"
        _health = health;
        _recoveryValue = recoveryValue;
        _recoverуHealthAfterStart = recoverуHealthAfterStart;

        _effectInGame_SO = GameEffectsStorage.Instance.GetEffectByType(_effectType);
    }

    /// <summary>
    /// Выполнение эффекта восстановления здоровья
    /// </summary>
    public override void DoEffect()
    {
        _health.ChangeHealth(_recoveryValue);
        base.DoEffect();
    }

    /// <summary>
    /// Возвращает описание эффекта
    /// </summary>
    public override string GetDescription()
    {
        string description = $"<b>{_effectInGame_SO.Title}</b>.<br>" +
            $"{_effectInGame_SO.Description}<br>" +
            $"Восстанавливает за ход: { _recoveryValue}<br>" +
            $"Осталось ходов: {MovesLeft}";
        return description;
    }

    /// <summary>
    /// Восстановление HP при старте
    /// </summary>
    public override void DoEffectAfterStart()
    {
        _health.ChangeHealth(_recoverуHealthAfterStart);
    }
}