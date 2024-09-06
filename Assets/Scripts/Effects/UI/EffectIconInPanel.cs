using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using Game.Effects;
using Game.Step;
using System.Collections;

namespace UI.Effects
{
    /// <summary>
    /// Иконка с эффектом на игроке
    /// </summary>
    public class EffectIconInPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [Tooltip("Иконка для эфекта")]
        [SerializeField] private Image _effectSprite = null;

        [Tooltip("Текстовое поле для количества ходов до окончания эффекта")]
        [SerializeField] private TMP_Text _movesLeftTMP = null;

        private BaseEffects _currentEffect = null;
        private Step _playerStepCheck = null;
        private DescriptionEffectCanvas _descriptionEffectCanvas;

        public void Init(BaseEffects baseEffects, Step playerStepCheck, DescriptionEffectCanvas descriptionEffectCanvas)
        {
            _currentEffect = baseEffects;
            _playerStepCheck = playerStepCheck;
            _descriptionEffectCanvas = descriptionEffectCanvas;
            _effectSprite.sprite = GetSpriteByEffect();

            _playerStepCheck.CompleteStepEvent += UpdateMovesLeft;
            StartCoroutine(UpdateMovesLeftRoutine());
        }

        /// <summary>
        /// обновление количества ходов в тексте
        /// </summary>
        private void UpdateMovesLeft() =>        
            _movesLeftTMP.text = _currentEffect.MovesLeft.ToString();
        
        /// <summary>
        /// Корутина обновления ходов
        /// </summary>
        private IEnumerator UpdateMovesLeftRoutine()
        {
            yield return new WaitForEndOfFrame();
            _movesLeftTMP.text = _currentEffect.MovesLeft.ToString();
        }

        /// <summary>
        /// Получаем спрайт эффекта
        /// </summary>
        private Sprite GetSpriteByEffect() =>
            GameEffectsStorage.Instance.GetEffectByType(_currentEffect.EffectType).Sprite;

        /// <summary>
        /// Когда навели мышкой на эффект
        /// </summary>
        public void OnPointerEnter(PointerEventData eventData)
        {
            //Debug.Log("Навели мышкой на эффект");
            _descriptionEffectCanvas.Init(_currentEffect);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            //Debug.Log("Отвели мышку с эффектом");
            _descriptionEffectCanvas.ReInit();
        }

        private void OnDisable()
        {
            _descriptionEffectCanvas.ReInit();
        }
    }
}
