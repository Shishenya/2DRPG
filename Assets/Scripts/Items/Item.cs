using System.Collections;
using UnityEngine;

/// <summary>
/// ������� �������
/// </summary>
[System.Serializable]
public class Item
{
    private protected int _id; // ID ��������
    private protected ItemType _type; // ��� ��������
    private protected int _maxStack; // ������������ ���������� ��������� � �����
    private protected float _weight; // ��� ��������
    private protected int _basicAmount; // ������� ���������
    private protected string _title; // �������� �������� 
    private protected string _description; // �������� ��������
    private protected Sprite _sprite; // ������

    public int Id { get=> _id; }

    public Item(int id)
    {
        _id = id;

        // ��������� ��������
        SetParameters();
    }

    /// <summary>
    /// ��������� ���������� ��� ��������
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
    /// ��������� ���������� ���������� �������� � ����������� �� ����
    /// </summary>
    public virtual void SetConcrectParameters() { }

    /// <summary>
    /// ��������� �������� ��������
    /// </summary>
    public virtual string GetDescription()
    {
        string result = $"<b>{_title}</b><br>" +
            $"{_description}<br>" +
            $"������� ����: <b>{_basicAmount}</b><br>" +
            $"���: <b>{_weight}</b><br>";

        return result;
    }

}
