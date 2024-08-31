using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������ ��� ������ � ���������, ������� ����� �� ������
/// </summary>
public class PlayerEffectsCanvas : MonoBehaviour
{
    [Tooltip("������ �������� ��� ������ � ���������")]
    [SerializeField] private Transform _backgroundPanel = null;

    [Tooltip("������ � ������� �������")]
    [SerializeField] private GameObject _iconPrefab = null;

    [Tooltip("������� ������")]
    [SerializeField] private CreatureEffects _playerEffects = null;

    [Tooltip("��������� ���� ������")]
    [SerializeField] private PlayerStepCheck _playerStepCheck = null;

    [Tooltip("������ � ��������� �������")]
    [SerializeField] private DescriptionEffectCanvas _descriptionEffectCanvas = null;

    // ������� � ��������� ������
    private Dictionary<BaseEffects, GameObject> _effectsInPanel = new Dictionary<BaseEffects, GameObject>();

    private void Awake()
    {
        _playerEffects.AddEffectEvent+=AddEffectToPanel;
        _playerEffects.RemoveEffectEvent += RemoveEffectToPanel;
    }

    void Start() { }

    /// <summary>
    /// ���������� �������� �� ������
    /// </summary>
    private void AddEffectToPanel(BaseEffects currentEffect)
    {
        GameObject iconEffect = Instantiate(_iconPrefab, _backgroundPanel);
        iconEffect.GetComponent<EffectIconInPanel>().Init(currentEffect, _playerStepCheck, _descriptionEffectCanvas);
        _effectsInPanel.Add(currentEffect, iconEffect);
    }

    /// <summary>
    /// �������� ������ � ������
    /// </summary>
    private void RemoveEffectToPanel(BaseEffects currentEffect)
    {
        if (_effectsInPanel.ContainsKey(currentEffect))
        {
            Destroy(_effectsInPanel[currentEffect]);
            _effectsInPanel.Remove(currentEffect);
        }
    }

}
