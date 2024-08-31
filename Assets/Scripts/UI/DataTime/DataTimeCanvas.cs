using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// ������ � ��������, ���������� �� ���� � �����
/// </summary>
public class DataTimeCanvas : MonoBehaviour
{
    [Tooltip("������� �����")]
    [SerializeField] private GameTime _gameTime;

    [Tooltip("��� ������")]
    [SerializeField] private PlayerStepCheck _playerStepCheck;

    [Tooltip("��������� ���� ��� ������� � ����")]
    [SerializeField] private TMP_Text _datatimeTMP;

    private void Awake()
    {
        _playerStepCheck.CompleteStepEvent += UpdateDataTimeCanvas;
        UpdateDataTimeCanvas();
    }

    /// <summary>
    /// ���������� ������� � ����
    /// </summary>
    private void UpdateDataTimeCanvas()
    {
        _datatimeTMP.text = _gameTime.DateTime.ToString();
    }
}
