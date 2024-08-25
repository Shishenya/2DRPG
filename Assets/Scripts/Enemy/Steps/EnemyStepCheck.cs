using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �������� �� ��������� ���� ������
/// </summary>
public class EnemyStepCheck : MonoBehaviour
{
    [SerializeField] private PlayerStepCheck _playerStepCheck = null;

    private void Awake()
    {
        _playerStepCheck.CompleteStepEvent += EnemyStepStart;
    }

    private void EnemyStepStart()
    {
        Debug.Log("����� ����!");
    }
}
