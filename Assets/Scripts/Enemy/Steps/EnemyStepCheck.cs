using UnityEngine;

namespace Game.Step
{

    /// <summary>
    /// �������� �� ��������� ���� ������
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
            Debug.Log("����� ����!");
        }
    }
}
