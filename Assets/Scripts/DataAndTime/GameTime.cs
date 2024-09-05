using System;
using UnityEngine;
using Game.Step;

namespace Game.Time
{
    /// <summary>
    /// ����� � � ���� � ����
    /// </summary>
    public class GameTime : MonoBehaviour
    {
        [Tooltip("��� ������")]
        [SerializeField] private PlayerStepCheck _playerStepCheck;

        private DateTime _dateTime = new DateTime();
        private double _incrementMinutes = 1;

        public DateTime DateTime { get => _dateTime; }

        private void Awake()
        {
            _playerStepCheck.CompleteStepEvent += IncrementTime;
        }

        /// <summary>
        /// ���������� �������
        /// </summary>
        private void IncrementTime()
        {
            _dateTime = _dateTime.AddMinutes(_incrementMinutes);
        }
    }
}
