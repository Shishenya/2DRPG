using Game.Body;
using Game.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace UI.Game.Body
{
    /// <summary>
    /// Иконка на канвасе с телом для доспехов
    /// </summary>
    public class PlayerBodyIconArmorUI : PlayerBodyIconUI, IPointerClickHandler
    {
        [Tooltip("Тип доспеха для данной иконки")]
        [SerializeField] private ArmorType _armorType;

        public ArmorType ArmorType { get => _armorType; }

        private Armor _currentArmor = null;
        private CreatureBody _body = null;

        /// <summary>
        /// Инициализация
        /// </summary>
        public void Init(CreatureBody body)
        {
            _body = body;
            _currentArmor = body.CreatureBodyDictionary[_armorType];
            if (_currentArmor != null)
                _image.sprite = GameItemsStorage.Instance.GetItemSOByID(_currentArmor.Id).Sprite;
            else
                _image.sprite = null;
        }

        public void ReInit()
        {
            _currentArmor = null;
            _image.sprite = null;
        }

        /// <summary>
        /// Снимаем предмет, если кликнули ПКМ
        /// </summary>
        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                ReInit();
                _body.RemoveArmor(_armorType);
            }
        }
    }
}
