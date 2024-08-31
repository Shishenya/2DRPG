using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Канвас для работы с эффектами, которые висят на игроке
/// </summary>
public class PlayerEffectsCanvas : MonoBehaviour
{
    [Tooltip("Панель родитель для иконок с эффектами")]
    [SerializeField] private Transform _backgroundPanel = null;

    [Tooltip("Префаб с иконкой эффекта")]
    [SerializeField] private GameObject _iconPrefab = null;

    [Tooltip("Эффекты игрока")]
    [SerializeField] private CreatureEffects _playerEffects = null;

    [Tooltip("Окончание хода игрока")]
    [SerializeField] private PlayerStepCheck _playerStepCheck = null;

    [Tooltip("Канвас с описанием эффекта")]
    [SerializeField] private DescriptionEffectCanvas _descriptionEffectCanvas = null;

    // Словарь с эффектами игрока
    private Dictionary<BaseEffects, GameObject> _effectsInPanel = new Dictionary<BaseEffects, GameObject>();

    private void Awake()
    {
        _playerEffects.AddEffectEvent+=AddEffectToPanel;
        _playerEffects.RemoveEffectEvent += RemoveEffectToPanel;
    }

    void Start() { }

    /// <summary>
    /// Добавление эффектов на панель
    /// </summary>
    private void AddEffectToPanel(BaseEffects currentEffect)
    {
        GameObject iconEffect = Instantiate(_iconPrefab, _backgroundPanel);
        iconEffect.GetComponent<EffectIconInPanel>().Init(currentEffect, _playerStepCheck, _descriptionEffectCanvas);
        _effectsInPanel.Add(currentEffect, iconEffect);
    }

    /// <summary>
    /// Удаление эфекта с панели
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
