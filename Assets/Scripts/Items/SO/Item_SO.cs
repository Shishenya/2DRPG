using System.Collections;
using UnityEngine;

/// <summary>
/// SO для создания предмета
/// </summary>
public class Item_SO : ScriptableObject
{
    [Tooltip("ID предмета")]
    [SerializeField] private protected int _id;
    [Tooltip("Название предмета")]
    [SerializeField] private protected string _title;
    [Tooltip("Описание предмета")]
    [SerializeField, TextArea(4, 10)] private protected string _description;
    [Tooltip("Тип предмета")]
    [SerializeField] private protected ItemType _type;
    [Tooltip("Максимальное количество предметов в стаке")]
    [SerializeField] private protected int _maxStack;
    [Tooltip("Вес предмета")]
    [SerializeField, Range(0.01f, 20f)] private protected float _weight = 0.01f;
    [Tooltip("Базовая стоимость")]
    [SerializeField] private protected int _basicAmount;
    [Tooltip("Иконка")]
    [SerializeField] private protected Sprite _sprite; // иконка


    public int Id { get => _id; }
    public string Title { get => _title; }
    public string Description { get => _description; }
    public ItemType Type { get => _type; }
    public int MaxStack { get => _maxStack; }
    public float Weight { get => _weight; }
    public int BasicAmount { get => _basicAmount; }    
    public Sprite Sprite { get => _sprite; }
}
