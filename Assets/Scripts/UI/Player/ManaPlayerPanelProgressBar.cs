public class ManaPlayerPanelProgressBar : PlayerPanelProgressBar
{
    /// <summary>
    /// Подписка на изменение значения маны
    /// </summary>
    public override void Subsribe()
    {
        Mana mana = (Mana)_creatureIndicator;
        mana.ChangeManaEvent += UpdateValuePanelProgressBar;
    }
}