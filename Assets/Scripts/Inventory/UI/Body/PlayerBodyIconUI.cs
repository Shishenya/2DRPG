using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Game.Body
{
    /// <summary>
    /// Иконка для предмета в разделе "Тело"
    /// </summary>
    public class PlayerBodyIconUI : MonoBehaviour
    {
        [Tooltip("Картинка для предмета")]
        [SerializeField] private Image _image;

        //private protected PlayerBodyIconType _bodyIconType;
    }
}
