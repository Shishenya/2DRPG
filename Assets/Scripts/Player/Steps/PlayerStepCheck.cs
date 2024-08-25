using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// ��������� ����� ���� � ���� ������� ������ �� ���
/// </summary>
public class PlayerStepCheck : MonoBehaviour
{
    public event Action CompleteStepEvent;

    private void Awake()
    {
        CompleteStepEvent += DebugEvent;
    }

    private void DebugEvent()
    {
        Debug.Log("Complete Step!");
    }

    /// <summary>
    /// ������� ������� ��������� ����
    /// </summary>
    public void CallCompleteStepEvent()
    {
        CompleteStepEvent?.Invoke();
    }
}
