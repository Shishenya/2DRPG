using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SO для создания эффектов в игре
/// </summary>
[CreateAssetMenu(fileName = "EffectInGame_SO_", menuName = "Effects/New Effect")]
public class EffectInGame_SO : ScriptableObject
{
    [Tooltip("Тип эффекта")]
    [SerializeField] private EffectType _type;
    [Tooltip("Название эффекта")]
    [SerializeField] private string _title;
    [Tooltip("Опиасание эффекта"), TextArea(4, 10)]
    [SerializeField] private string _description;
    [Tooltip("Иконка")]
    [SerializeField] private Sprite _sprite;

    public EffectType Type { get => _type; }
    public string Title { get => _title; }
    public string Description { get => _description; }
    public Sprite Sprite { get => _sprite; }
}
