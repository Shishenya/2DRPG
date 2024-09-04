using System.Collections;
using UnityEngine;

/// <summary>
/// Игровой предмет
/// </summary>
[System.Serializable]
public class Item
{
    private protected int _id; // ID предмета
    private protected ItemType _type; // тип предмета
    private protected int _maxStack; // максимальное количество предметов в стаке
    private protected float _weight; // вес предмета
    private protected int _basicAmount; // базовая стоимость
    private protected string _title; // название предмета 
    private protected string _description; // описание предмета
    private protected Sprite _sprite; // иконка

    public int Id { get=> _id; }

    public Item(int id)
    {
        _id = id;

        // Установка значений
        SetParameters();
    }

    /// <summary>
    /// Установка параметров для предмета
    /// </summary>
    private void SetParameters()
    {
        Item_SO item_SO = GameItemsStorage.Instance.GetItemSOByID(_id);
        if (item_SO != null)
        {
            _type = item_SO.Type;
            _maxStack = item_SO.MaxStack;
            _weight = item_SO.Weight;
            _basicAmount = item_SO.BasicAmount;
            _title = item_SO.Title;
            _description = item_SO.Description;
            _sprite = item_SO.Sprite;
        }
    }

    /// <summary>
    /// Наложение конкретных параметров предмета в зависимости от типа
    /// </summary>
    public virtual void SetConcrectParameters() { }

    /// <summary>
    /// Получение описания предмета
    /// </summary>
    public virtual string GetDescription()
    {
        string result = $"<b>{_title}</b><br>" +
            $"{_description}<br>" +
            $"Базовая цена: <b>{_basicAmount}</b><br>" +
            $"Вес: <b>{_weight}</b><br>";

        return result;
    }

}
