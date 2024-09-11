using TMPro;
using UnityEngine;

/// <summary>
/// Прогрессивный панель бар с показателями игрока
/// </summary>
public class PlayerPanelProgressBar : MonoBehaviour
{
    [Tooltip("Текстовое поле для значения")]
    [SerializeField] private TMP_Text _valueTMP = null;
    [Tooltip("Панель с бэгроундом")]
    [SerializeField] private RectTransform _backPanel = null;
    [Tooltip("Панель с значением")]
    [SerializeField] private RectTransform _valuePanel = null;

    private float _startWidth = 0f;

    [Tooltip("Какой показатель обрабатывать?")]
    [SerializeField] private protected CreatureIndicators _creatureIndicator = null;


    private void Awake()
    {
        _startWidth = _valuePanel.sizeDelta.x;        
    }

    private void Start()
    {
        Subsribe();
        UpdateValuePanelProgressBar();
    }

    /// <summary>
    /// Подписка на события обновления показателя
    /// </summary>
    public virtual void Subsribe() { }


    /// <summary>
    /// Обновление значения прогресс панели бара
    /// </summary>
    public virtual void UpdateValuePanelProgressBar()
    {
        Vector2 sizeDelta = _valuePanel.sizeDelta;
        float newSize = _startWidth * (_creatureIndicator.Percent);
        sizeDelta.x = newSize;

        _valuePanel.sizeDelta = sizeDelta;

        UpdateTMP();
    }

    /// <summary>
    /// Обновление текстового поля
    /// </summary>
    private void UpdateTMP() =>    
        _valueTMP.text = $"{_creatureIndicator.CurrentValue}/{_creatureIndicator.MaxValue}";    
}
