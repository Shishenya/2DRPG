using UnityEngine;

namespace Game.Step
{
    /// <summary>
    /// ��������� ����� ���� � ���� ������� ������ �� ���
    /// </summary>
    public class PlayerStepCheck : Step
    {
        
        public override void Awake()
        {
            CompleteStepEvent += DebugEvent;
        }

        private void DebugEvent()
        {
            Debug.Log("Complete Step!");
        }
    }
}
