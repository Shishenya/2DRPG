using UnityEngine;

/// <summary>
/// Объект, который уменьшает жизни игрока или другого существа
/// </summary>
public class DamageObject : MonoBehaviour
{
    [Tooltip("Сколько урона наносит данный объект?")]
    [SerializeField] private float _damageValue = 1f;

    private OverlayEffect[] _overlayEffects = null; // эффекты, которые мы наложим при столкновении

    private void Start() {
        _overlayEffects = GetComponents<OverlayEffect>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out Health health))
        {
            health.ChangeHealth(-1 * _damageValue);
            OverlayEffect(collision.gameObject);
        }
    }

    /// <summary>
    /// Наложение эффектов при столкновении
    /// </summary>
    private void OverlayEffect(GameObject go)
    {
        foreach (var item in _overlayEffects)        
            item.Overlay(go);        
    }
}