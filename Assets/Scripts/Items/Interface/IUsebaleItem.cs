using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Items
{
    /// <summary>
    /// Интерфейс юзабельных предметов
    /// </summary>
    public interface IUsebaleItem
    {
        public void Use(GameObject target); // Использовать
    }
}
