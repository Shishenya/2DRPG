using UnityEngine;
using System;

/// <summary>
/// ���������
/// </summary>
public class Fatigue : CreatureIndicators
{
    [Tooltip("��������� �������� ���������")]
    [SerializeField] private float _startFatigue = 100f;

    [SerializeField] private float _maxFatigue = 100f;
    public float MaxFatigue { get => _maxFatigue; }

    public event Action ChangeFatigueEvent;

    private float _currentFatigue = 0f;
    public float CurrentFatigue { get => _currentFatigue; }


    public override float CurrentValue => _currentFatigue;
    public override float MaxValue => MaxFatigue;

    private void Awake()
    {
        _currentFatigue = _startFatigue;
    }

    private void Start() { }

    /// <summary>
    /// ��������� ���������
    /// </summary>
    public void ChangeHealth(int value)
    {
        _currentFatigue += value;
        ChangeFatigueEvent?.Invoke();
    }
}
