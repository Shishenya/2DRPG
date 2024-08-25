using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���������
/// </summary>
public class Fatigue : MonoBehaviour
{
    [Tooltip("��������� �������� ���������")]
    [SerializeField] private float _startFatigue = 100;

    private float _currentFatigue = 0f;

    private void Awake()
    {
        _currentFatigue = _startFatigue;
    }

    private void Start() { }
}
