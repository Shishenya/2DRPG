using UnityEngine;

/// <summary>
/// Базовый класс для наложения эффекта
/// </summary>
public class OverlayEffect : MonoBehaviour
{
    /// <summary>
    /// Наложение эффекта на что-то
    /// </summary>
    
    private protected void Start() { }

    public virtual void Overlay(GameObject gameObject) { }
}
