
/// <summary>
/// Ячейка в инвентаре
/// </summary>
[System.Serializable]
public class InventoryCell
{
    private int _idItem; // ID предмета
    private int _count; // его количество

    public int IdItem { get=> _idItem; }
    public int Count { get=> _count; }

    public InventoryCell(int idItem, int count)
    {
        _idItem = idItem;
        _count = count;
    }

    /// <summary>
    /// Обновление количества предметов
    /// </summary>
    public void UpdateCount(int idItem, int value)
    {
        if (idItem != _idItem) return;
        _count += value;
    }
}
