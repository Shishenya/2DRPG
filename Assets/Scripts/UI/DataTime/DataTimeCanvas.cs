using UnityEngine;
using TMPro;
using Game.Step;
using Game.Time;

namespace UI.Time
{
    /// <summary>
    /// Работа с канвасом, отвечающее за дату и время
    /// </summary>
    public class DataTimeCanvas : MonoBehaviour
    {
        [Tooltip("Игровое время")]
        [SerializeField] private GameTime _gameTime;

        [Tooltip("Ход игрока")]
        [SerializeField] private PlayerStepCheck _playerStepCheck;

        [Tooltip("Текстовое поле для времени и даты")]
        [SerializeField] private TMP_Text _datatimeTMP;

        private void Awake()
        {
            _playerStepCheck.CompleteStepEvent += UpdateDataTimeCanvas;
            UpdateDataTimeCanvas();
        }

        /// <summary>
        /// Обновление времени и даты
        /// </summary>
        private void UpdateDataTimeCanvas()
        {
            _datatimeTMP.text = _gameTime.DateTime.ToString();
        }
    }
}
