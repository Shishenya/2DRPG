using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using Game.Effects;
using Game.Step;

namespace UI.Effects
{

    /// <summary>
    /// ������ � �������� �� ������
    /// </summary>
    public class EffectIconInPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [Tooltip("������ ��� ������")]
        [SerializeField] private Image _effectSprite = null;

        [Tooltip("��������� ���� ��� ���������� ����� �� ��������� �������")]
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

            playerStepCheck.CompleteStepEvent += UpdateMovesLeft;
            UpdateMovesLeft();
        }

        private void UpdateMovesLeft()
        {
            //_movesLeftTMP.text = _currentEffect.MovesLeft.ToString();
        }

        /// <summary>
        /// �������� ������ �������
        /// </summary>
        private Sprite GetSpriteByEffect() =>
            GameEffectsStorage.Instance.GetEffectByType(_currentEffect.EffectType).Sprite;

        /// <summary>
        /// ����� ������ ������ �� ������
        /// </summary>
        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("������ ������ �� ������");
            _descriptionEffectCanvas.Init(_currentEffect);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Debug.Log("������ ����� � ��������");
            _descriptionEffectCanvas.ReInit();
        }
    }
}
