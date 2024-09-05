using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Step
{
    /// <summary>
    /// ���� �������
    /// </summary>
    public class Step : MonoBehaviour
    {
        public event Action CompleteStepEvent; // ������� ��������� ����

        public virtual void Awake()  { }
        public virtual void Start() { }

        /// <summary>
        /// ������� ������� ��������� ����
        /// </summary>
        public void CallCompleteStepEvent()
        {
            CompleteStepEvent?.Invoke();
        }

    }
}
