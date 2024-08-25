using UnityEngine;

/// <summary>
/// Здоровье
/// </summary>
public class Health : MonoBehaviour
{
    [Tooltip("Стартовое здоровье")]
    [SerializeField] private float _startHealth = 100;

    private float _currentHealth = 0f;

    private void Awake()
    {
        _currentHealth = _startHealth;
    }

    private void Start() { }
}
