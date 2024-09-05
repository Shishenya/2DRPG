using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Предметы, которые имеют эффект при использовании
/// </summary>
public class ItemDoEffectSO: Item_SO
{
    [Tooltip("Эффекты, которые накладывает данный предмет при использовании")]
    [SerializeField] private protected List<EffectType> _effects;

    //[Tooltip("Эффекты, которые накладываются при применении")]
    //[SerializeField] private protected List<OverlayEffect> _overlayEffects;

    public List<EffectType> Effects { get => _effects; }
    //public List<OverlayEffect> OverlayEffects { get=> _overlayEffects;}
}
