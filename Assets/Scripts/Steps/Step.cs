using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Step
{
    /// <summary>
    /// Шаги игроков
    /// </summary>
    public class Step : MonoBehaviour
    {
        public event Action CompleteStepEvent; // событие окончания хода

        public virtual void Awake()  { }
        public virtual void Start() { }

        /// <summary>
        /// Провзон события окончания шага
        /// </summary>
        public void CallCompleteStepEvent()
        {
            CompleteStepEvent?.Invoke();
        }

    }
}
