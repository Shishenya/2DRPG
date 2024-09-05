using UnityEngine;

namespace Game.Step
{

    /// <summary>
    /// Действие на окончание шага игрока
    /// </summary>
    public class EnemyStepCheck : Step
    {
        [SerializeField] private PlayerStepCheck _playerStepCheck = null;

        public override void Awake()
        {
            _playerStepCheck.CompleteStepEvent += EnemyStepStart;
        }

        private void EnemyStepStart()
        {
            Debug.Log("Ходит враг!");
        }
    }
}
