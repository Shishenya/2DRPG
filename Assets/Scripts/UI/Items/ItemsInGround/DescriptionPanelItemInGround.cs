using UnityEngine;
using TMPro;

/// <summary>
/// Панель с описанием предмета
/// </summary>
public class DescriptionPanelItemInGround : MonoBehaviour
{
    [Tooltip("Куда выводить описание")]
    [SerializeField] private TMP_Text _descriptionText;

    private Item _current;

    /// <summary>
    /// Инициализация
    /// </summary>
    public void Init(Item item)
    {
        _current = item;
        _descriptionText.text = _current.GetDescription();
    }

    /// <summary>
    /// реинициализация
    /// </summary>
    public void ReInit()
    {
        _current = null;
        _descriptionText.text = string.Empty;
    }

}
