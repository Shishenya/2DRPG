using UnityEngine;

/// <summary>
/// ������, ������� ��������� ����� ������ ��� ������� ��������
/// </summary>
public class DamageObject : MonoBehaviour
{
    [Tooltip("������� ����� ������� ������ ������?")]
    [SerializeField] private float _damageValue = 1f;

    private OverlayEffect[] _overlayEffects = null; // �������, ������� �� ������� ��� ������������

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
    /// ��������� �������� ��� ������������
    /// </summary>
    private void OverlayEffect(GameObject go)
    {
        foreach (var item in _overlayEffects)        
            item.Overlay(go);        
    }
}