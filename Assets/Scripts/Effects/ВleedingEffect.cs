
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
        _health = health;
        _damage = damage;
    }

    public override void DoEffect() {
        Debug.Log("Выполняю эффект кровотечения");
        _health.ChangeHealth(_damage);
        base.DoEffect();
    }
}
