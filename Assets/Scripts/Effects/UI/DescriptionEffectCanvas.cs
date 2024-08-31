using UnityEngine;
using TMPro;

/// <summary>
/// Канвас для работы с эффектами
/// </summary>
public class DescriptionEffectCanvas : MonoBehaviour
{
    [Tooltip("Панель с подсказкой")]
    [SerializeField] private GameObject _backgroundPanel = null;

    [Tooltip("Описание эффекта")]
    [SerializeField] private TMP_Text _descriptionTMP = null;

    private BaseEffects _currentEffect; // Текущий эффект

    /// <summary>
    /// Инициализация панели с подсказкой
    /// </summary>
    public void Init(BaseEffects effect)
    {
        _currentEffect = effect;
        _backgroundPanel.SetActive(true);
        _descriptionTMP.text = _currentEffect.GetDescription();
        _backgroundPanel.transform.position = Input.mousePosition;
    }

    /// <summary>
    /// Отключение панели
    /// </summary>
    public void ReInit()
    {
        _currentEffect = null;
        _backgroundPanel.SetActive(false);
        _descriptionTMP.text = "";
    }
}
