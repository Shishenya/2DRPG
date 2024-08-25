using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Усталость
/// </summary>
public class Fatigue : MonoBehaviour
{
    [Tooltip("Стартовое значение усталости")]
    [SerializeField] private float _startFatigue = 100;

    private float _currentFatigue = 0f;

    private void Awake()
    {
        _currentFatigue = _startFatigue;
    }

    private void Start() { }
}
