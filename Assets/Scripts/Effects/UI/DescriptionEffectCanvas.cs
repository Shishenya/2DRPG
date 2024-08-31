using UnityEngine;
using TMPro;

/// <summary>
/// ������ ��� ������ � ���������
/// </summary>
public class DescriptionEffectCanvas : MonoBehaviour
{
    [Tooltip("������ � ����������")]
    [SerializeField] private GameObject _backgroundPanel = null;

    [Tooltip("�������� �������")]
    [SerializeField] private TMP_Text _descriptionTMP = null;

    private BaseEffects _currentEffect; // ������� ������

    /// <summary>
    /// ������������� ������ � ����������
    /// </summary>
    public void Init(BaseEffects effect)
    {
        _currentEffect = effect;
        _backgroundPanel.SetActive(true);
        _descriptionTMP.text = _currentEffect.GetDescription();
        _backgroundPanel.transform.position = Input.mousePosition;
    }

    /// <summary>
    /// ���������� ������
    /// </summary>
    public void ReInit()
    {
        _currentEffect = null;
        _backgroundPanel.SetActive(false);
        _descriptionTMP.text = "";
    }
}
