using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Предметы, которые лежат на чем либо (карта, игрок) и т.д.
/// </summary>
public class Items : MonoBehaviour
{
    [Tooltip("Список ID предметов, которые лежат")]
    [SerializeField] private List<int> _items;

    public List<int> items { get => _items; }
}
