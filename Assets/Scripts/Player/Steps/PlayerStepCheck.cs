using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// ѕровер€ем конец хода и дает команду других на ход
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
    /// ѕрозвон событи€ окончани€ шага
    /// </summary>
    public void CallCompleteStepEvent()
    {
        CompleteStepEvent?.Invoke();
    }
}
