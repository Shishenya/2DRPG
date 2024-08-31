using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���������� ��������� ��� �������� � ����
/// </summary>
public class GameEffectsStorage : MonoBehaviour
{
    [Tooltip("��� ������� � ����")]
    [SerializeField] private List<EffectInGame_SO> _effectsInGame_SO;

    private Dictionary<EffectType, EffectInGame_SO> _dictionary = new Dictionary<EffectType, EffectInGame_SO>();

    public static GameEffectsStorage Instance;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
        CreateEffectDictionary();
    }

    /// <summary>
    /// �������� ������� � ���������
    /// </summary>
    private void CreateEffectDictionary()
    {
        _dictionary.Clear();
        foreach (var item in _effectsInGame_SO)        
            _dictionary.Add(item.Type, item);        
    }

    /// <summary>
    /// ���������� �������� ������� �� ��� ����
    /// </summary>
    public EffectInGame_SO GetEffectByType(EffectType type)
    {
        if (_dictionary.ContainsKey(type))
            return _dictionary[type];

        return null;
    }
}
