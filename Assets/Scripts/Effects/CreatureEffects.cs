using System.Collections.Generic;
using UnityEngine;
using System;

namespace Game.Effects
{
    /// <summary>
    /// �������, ���������� �� ������������ ��������
    /// </summary>
    public class CreatureEffects : MonoBehaviour
    {

        private List<BaseEffects> _effects = new List<BaseEffects>();

        public event Action<BaseEffects> AddEffectEvent;
        public event Action<BaseEffects> RemoveEffectEvent;

        private void Start() { }

        /// <summary>
        /// ���������� �������
        /// </summary>
        public void AddEffect(BaseEffects effect)
        {
            _effects.Add(effect);
            AddEffectEvent?.Invoke(effect);
        }

        /// <summary>
        /// �������� �������
        /// </summary>
        public void RemoveEffect(BaseEffects effect)
        {
            _effects.Remove(effect);
            RemoveEffectEvent?.Invoke(effect);
        }
 
    }
}
