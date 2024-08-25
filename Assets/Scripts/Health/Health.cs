using UnityEngine;

/// <summary>
/// ��������
/// </summary>
public class Health : MonoBehaviour
{
    [Tooltip("��������� ��������")]
    [SerializeField] private float _startHealth = 100;

    private float _currentHealth = 0f;

    private void Awake()
    {
        _currentHealth = _startHealth;
    }

    private void Start() { }
}
