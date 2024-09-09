using Game.Parameters;
using UnityEngine;

/// <summary>
/// SO для предметов типа "Броня"
/// </summary>
[CreateAssetMenu(fileName = "ArmorItem_SO_", menuName = "Item/ New Item Armor")]
public class ArmorItemSO : Item_SO
{
    [Space(15)]
    [Header("Настройка для брони")]
    [Space(10)]
    [Tooltip("Тип брони")]
    [SerializeField] private protected ArmorType _armorType;
    [Tooltip("Очки брони")]
    [SerializeField] private int _armorValue;

    [Tooltip("Как меняются параметры при одевании данного предмета?")]
    [SerializeField] private Сharacteristics _changeСharacteristics;


    public ArmorType ArmorType { get => _armorType; }
    public Сharacteristics ChangeValue { get => _changeСharacteristics; }
    public int ArmorValue { get => _armorValue;  }
}