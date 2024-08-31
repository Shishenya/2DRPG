using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SO ��� �������� �������� � ����
/// </summary>
[CreateAssetMenu(fileName = "EffectInGame_SO_", menuName = "Effects/New Effect")]
public class EffectInGame_SO : ScriptableObject
{
    [Tooltip("��� �������")]
    [SerializeField] private EffectType _type;
    [Tooltip("�������� �������")]
    [SerializeField] private string _title;
    [Tooltip("��������� �������"), TextArea(4, 10)]
    [SerializeField] private string _description;
    [Tooltip("������")]
    [SerializeField] private Sprite _sprite;

    public EffectType Type { get => _type; }
    public string Title { get => _title; }
    public string Description { get => _description; }
    public Sprite Sprite { get => _sprite; }
}
