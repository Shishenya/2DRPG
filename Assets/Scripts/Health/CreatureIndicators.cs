using UnityEngine;

/// <summary>
/// Некоторый показатель существа
/// </summary>
public class CreatureIndicators : MonoBehaviour
{
    public virtual float CurrentValue { get; }
    public virtual float MaxValue { get; }
    public float Percent { get => CurrentValue / MaxValue; }

}
