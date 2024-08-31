using UnityEngine;

/// <summary>
/// Панель прогресса с HP игрока
/// </summary>
public class HealthPlayerPanelProgressBar: PlayerPanelProgressBar
{

    /// <summary>
    /// Подписка на изменение значения жизней
    /// </summary>
    public override void Subsribe()
    {
        Health health = (Health)_creatureIndicator;
        health.ChangeHealthEvent += UpdateValuePanelProgressBar;        
    }
}