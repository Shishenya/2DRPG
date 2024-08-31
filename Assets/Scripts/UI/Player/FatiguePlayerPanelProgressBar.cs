public class FatiguePlayerPanelProgressBar : PlayerPanelProgressBar
{

    /// <summary>
    /// Подписка на изменение значения жизней
    /// </summary>
    public override void Subsribe()
    {
        Fatigue fatigue = (Fatigue)_creatureIndicator;
        fatigue.ChangeFatigueEvent += UpdateValuePanelProgressBar;
    }
}