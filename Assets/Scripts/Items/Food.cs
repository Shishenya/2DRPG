using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Тип предмета - еда
/// </summary>
public class Food: Item
{
    private protected List<OverlayEffect> _overlayEffects;

    public Food(int id) : base (id)
    {
        SetConcrectParameters();
    }

    /// <summary>
    /// Добавление конкретных параметров для еды
    /// </summary>
    public override void SetConcrectParameters()
    {
        ItemFood_SO itemFood_SO = (ItemFood_SO)GameItemsStorage.Instance.GetItemSOByID(_id);
        _overlayEffects = itemFood_SO.OverlayEffects;
        if (_overlayEffects != null)
            Debug.Log("Успешно создал еду");
        else
            Debug.Log("Облом. Еда не создана!");
    }

    /// <summary>
    /// переопределенный метод с описанием предмета (еда)
    /// </summary>
    public override string GetDescription()
    {
        string result = base.GetDescription();
        result += $"<br>" +
            $"Накладываются эффекты: <br>";

        return result;
    }
}
