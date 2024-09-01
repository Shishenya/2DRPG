using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Эффекты, наложенные на определенное существо
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
    /// Добавление эффекта
    /// </summary>
    public void AddEffect(BaseEffects currentEffect)
    {
        _baseEffects.Add(currentEffect); // добавляем эффект в список
        currentEffect.DoEffectAfterStart(); // выполняем данный эффект при его добавлении

        if (currentEffect.MovesLeft > 0) // если эффект не мгновенный, то...
        {
            AddEffectEvent?.Invoke(currentEffect); // выполняем действия при его добавлении
            currentEffect.EffectCompletedEvent += RemoveEffect; // добавляем его в спсок на удаление
        }
    }

    /// <summary>
    /// Удаление эффекта
    /// </summary>
    public void RemoveEffect(BaseEffects currentEffect)
    {
        Debug.Log("Эффект закончился!");
        RemoveEffectEvent?.Invoke(currentEffect);
        _removeList.Add(currentEffect);
        currentEffect.EffectCompletedEvent -= RemoveEffect;
    }

    /// <summary>
    /// Выполнение всех эффектов
    /// </summary>
    public void ExecuteAllEffects()
    {
        //Debug.Log("Выполняю все эффекты!");
        foreach (var item in _baseEffects)        
            item.DoEffect();

        // Очищаем лист эффеектов, которые закончились
        foreach (var item in _removeList)        
            _baseEffects.Remove(item);        

        _removeList.Clear();
    }
}
