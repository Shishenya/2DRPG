using UnityEngine;
using System;

/// <summary>
/// Мана
/// </summary>
public class Mana : CreatureIndicators
{
    [Tooltip("Стартовое значение маны")]
    [SerializeField] private float _startMana = 100f;

    [SerializeField]  private float _maxMana = 100f;
    public float MaxMana { get => _maxMana; }

    public event Action ChangeManaEvent;

    private float _currentMana = 0f;
    public float CurrentMana { get => _currentMana; }

    public override float CurrentValue => _currentMana;
    public override float MaxValue => MaxMana;

    private void Awake()
    {
        _currentMana = _startMana;
    }

    private void Start() { }

    /// <summary>
    /// Изменение значения маны
    /// </summary>
    public void ChangeMana(int value)
    {
        _currentMana += value;
        ChangeManaEvent?.Invoke();
    }
}
