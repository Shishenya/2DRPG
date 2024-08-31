using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

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
    private PlayerStepCheck _playerStepCheck = null;
    private DescriptionEffectCanvas _descriptionEffectCanvas;

    public void Init(BaseEffects baseEffects, PlayerStepCheck playerStepCheck, DescriptionEffectCanvas descriptionEffectCanvas)
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
        Debug.Log("Навели мышкой на эффект");
        _descriptionEffectCanvas.Init(_currentEffect);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Отвели мышку с эффектом");
        _descriptionEffectCanvas.ReInit();
    }
}
