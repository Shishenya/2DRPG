using System.Collections;
using UnityEngine;

/// <summary>
/// SO ��� �������� ��������
/// </summary>
public class Item_SO : ScriptableObject
{
    [Tooltip("ID ��������")]
    [SerializeField] private protected int _id;
    [Tooltip("�������� ��������")]
    [SerializeField] private protected string _title;
    [Tooltip("�������� ��������")]
    [SerializeField, TextArea(4, 10)] private protected string _description;
    [Tooltip("��� ��������")]
    [SerializeField] private protected ItemType _type;
    [Tooltip("������������ ���������� ��������� � �����")]
    [SerializeField] private protected int _maxStack;
    [Tooltip("��� ��������")]
    [SerializeField, Range(0.01f, 20f)] private protected float _weight = 0.01f;
    [Tooltip("������� ���������")]
    [SerializeField] private protected int _basicAmount;
    [Tooltip("������")]
    [SerializeField] private protected Sprite _sprite; // ������


    public int Id { get => _id; }
    public string Title { get => _title; }
    public string Description { get => _description; }
    public ItemType Type { get => _type; }
    public int MaxStack { get => _maxStack; }
    public float Weight { get => _weight; }
    public int BasicAmount { get => _basicAmount; }    
    public Sprite Sprite { get => _sprite; }
}
