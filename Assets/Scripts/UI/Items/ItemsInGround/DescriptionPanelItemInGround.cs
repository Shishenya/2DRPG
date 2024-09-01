using UnityEngine;
using TMPro;

/// <summary>
/// ������ � ��������� ��������
/// </summary>
public class DescriptionPanelItemInGround : MonoBehaviour
{
    [Tooltip("���� �������� ��������")]
    [SerializeField] private TMP_Text _descriptionText;

    private Item _current;

    /// <summary>
    /// �������������
    /// </summary>
    public void Init(Item item)
    {
        _current = item;
        _descriptionText.text = _current.GetDescription();
    }

    /// <summary>
    /// ���������������
    /// </summary>
    public void ReInit()
    {
        _current = null;
        _descriptionText.text = string.Empty;
    }

}
