using System.Collections.Generic;
using UnityEngine;
using Game.Effects;

/// <summary>
/// Предметы, которые имеют эффект при использовании
/// </summary>
public class ItemDoEffectSO: Item_SO
{
    [Tooltip("Эффекты, которые накладывает данный предмет при использовании")]
    [SerializeField] private protected List<EffectParameters> _effects;

    public List<EffectParameters> Effects { get => _effects; }
    
}
