using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��������, ������� ����� �� ��� ���� (�����, �����) � �.�.
/// </summary>
public class Items : MonoBehaviour
{
    [Tooltip("������ ID ���������, ������� �����")]
    [SerializeField] private List<int> _items;

    public List<int> items { get => _items; }
}
