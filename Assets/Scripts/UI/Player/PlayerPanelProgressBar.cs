using TMPro;
using UnityEngine;

/// <summary>
/// ������������� ������ ��� � ������������ ������
/// </summary>
public class PlayerPanelProgressBar : MonoBehaviour
{
    [Tooltip("��������� ���� ��� ��������")]
    [SerializeField] private TMP_Text _valueTMP = null;
    [Tooltip("������ � ����������")]
    [SerializeField] private RectTransform _backPanel = null;
    [Tooltip("������ � ���������")]
    [SerializeField] private RectTransform _valuePanel = null;

    private float _startWidth = 0f;

    [Tooltip("����� ���������� ������������?")]
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
    /// �������� �� ������� ���������� ����������
    /// </summary>
    public virtual void Subsribe() { }


    /// <summary>
    /// ���������� �������� �������� ������ ����
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
    /// ���������� ���������� ����
    /// </summary>
    private void UpdateTMP() =>    
        _valueTMP.text = $"{_creatureIndicator.CurrentValue}/{_creatureIndicator.MaxValue}";    
}
