using UnityEngine;

/// <summary>
/// Объект, который уменьшает жизни игрока или другого существа
/// </summary>
public class DamageObject : MonoBehaviour
{
    [Tooltip("Сколько урона наносить данный объект?")]
    [SerializeField] private float _damageValue = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out Health health))
            health.ChangeHealth(-1 * _damageValue);
    }
}
