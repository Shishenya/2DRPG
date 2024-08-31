using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �������, ���������� �� ������������ ��������
/// </summary>
public class CreatureEffects : MonoBehaviour
{
    private List<BaseEffects> _baseEffects = new List<BaseEffects>();
    private PlayerStepCheck _playerStepCheck = null;

    private List<BaseEffects> _removeList = new List<BaseEffects>();

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
        _baseEffects.Add(currentEffect);
        currentEffect.EffectCompletedEvent += RemoveEffect;
    }

    /// <summary>
    /// �������� �������
    /// </summary>
    public void RemoveEffect(BaseEffects currentEffect)
    {
        Debug.Log("������ ����������!");
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
