using UnityEngine;

/// <summary>
/// ������, ������� ��������� ����� ������ ��� ������� ��������
/// </summary>
public class DamageObject : MonoBehaviour
{
    [Tooltip("������� ����� �������� ������ ������?")]
    [SerializeField] private float _damageValue = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out Health health))
            health.ChangeHealth(-1 * _damageValue);
    }
}
