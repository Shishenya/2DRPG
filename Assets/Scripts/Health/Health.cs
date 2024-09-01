using UnityEngine;
using System;

/// <summary>
/// Здоровье
/// </summary>
public class Health : CreatureIndicators
{
    [Tooltip("Стартовое здоровье")]
    [SerializeField] private float _startHealth = 100f;
    [SerializeField]  private float _maxHealth = 100f;
    public float MaxHealth { get => _maxHealth; }

    public event Action ChangeHealthEvent;

    private float _currentHealth = 0f;
    public float CurrentHealth { get => _currentHealth; }


    public override float CurrentValue => CurrentHealth;
    public override float MaxValue => MaxHealth;

    private void Awake()
    {
        _currentHealth = _startHealth;
        //Debug.Log($"Percent = {Percent}; ");
    }

    private void Start() { }

    /// <summary>
    /// Изменение здоровья
    /// </summary>
    public void ChangeHealth(float value)
    {
        _currentHealth += value;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);

        ChangeHealthEvent?.Invoke();
    }

}
