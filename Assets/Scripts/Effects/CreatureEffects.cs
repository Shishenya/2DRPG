using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// �������, ���������� �� ������������ ��������
/// </summary>
public class CreatureEffects : MonoBehaviour
{
    private List<BaseEffects> _baseEffects = new List<BaseEffects>();
    private PlayerStepCheck _playerStepCheck = null;

    private List<BaseEffects> _removeList = new List<BaseEffects>();

    public event Action<BaseEffects> AddEffectEvent;
    public event Action<BaseEffects> RemoveEffectEvent;

    private void Start()
    {
        _playerStepCheck = GetComponent<PlayerStepCheck>();
        _playerStepCheck.CompleteStepEvent += ExecuteAllEffects;
    }

    /// <summary>
    /// ���������� �������
    /// </summary>
    public void AddEffect(BaseEffects currentEffect)
    {
        _baseEffects.Add(currentEffect); // ��������� ������ � ������
        currentEffect.DoEffectAfterStart(); // ��������� ������ ������ ��� ��� ����������

        if (currentEffect.MovesLeft > 0) // ���� ������ �� ����������, ��...
        {
            AddEffectEvent?.Invoke(currentEffect); // ��������� �������� ��� ��� ����������
            currentEffect.EffectCompletedEvent += RemoveEffect; // ��������� ��� � ����� �� ��������
        }
    }

    /// <summary>
    /// �������� �������
    /// </summary>
    public void RemoveEffect(BaseEffects currentEffect)
    {
        Debug.Log("������ ����������!");
        RemoveEffectEvent?.Invoke(currentEffect);
        _removeList.Add(currentEffect);
        currentEffect.EffectCompletedEvent -= RemoveEffect;
    }

    /// <summary>
    /// ���������� ���� ��������
    /// </summary>
    public void ExecuteAllEffects()
    {
        //Debug.Log("�������� ��� �������!");
        foreach (var item in _baseEffects)        
            item.DoEffect();

        // ������� ���� ���������, ������� �����������
        foreach (var item in _removeList)        
            _baseEffects.Remove(item);        

        _removeList.Clear();
    }
}
