using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Мана
/// </summary>
public class Mana : MonoBehaviour
{
    [Tooltip("Стартовое значение маны")]
    [SerializeField] private float _startMana = 100f;

    private float _currentMana = 0f;

    private void Awake()
    {
        _currentMana = _startMana;
    }

    private void Start() { }
}
