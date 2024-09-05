using UnityEngine;

namespace Game.Step
{
    /// <summary>
    /// ѕровер€ем конец хода и дает команду других на ход
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
