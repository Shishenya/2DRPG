using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��������, ������� ����� �� �����
/// </summary>
public class ItemsInGround : MonoBehaviour
{
    private Items _items; // ��������, ������� ����� �� �����
    private SpriteRenderer _spriteRenderer; // ������ ��� ��������� �� �����

    private void Awake()
    {
        _items = GetComponent<Items>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        CreateIcon(); // �������� ������ ��� ��������� �� �����
    }

    /// <summary>
    /// �������� ������ ��� �������� �� �����
    /// </summary>
    private void CreateIcon()
    {
        if (_items.items.Count > 1)
            _spriteRenderer.sprite = GameItemsStorage.Instance.DefaultSprite;
        else
        {
            Sprite sprite = GameItemsStorage.Instance.GetItemSOByID(_items.items[0]).Sprite;
            _spriteRenderer.sprite = sprite;
        }
    }    

    /// <summary>
    /// ����� � ���������
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsPlayer(collision)) return;
        Debug.Log("����� � ���������");
        ItemsInGroundCanvas.Instance.Init(_items);
    }

    /// <summary>
    /// ����� �� ����
    /// </summary>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!IsPlayer(collision)) return;
        ItemsInGroundCanvas.Instance.ReInit();
        Debug.Log("����� �� ����");
    }

    /// <summary>
    /// �������� �� ������
    /// </summary>
    private bool IsPlayer(Collider2D collision) =>    
        collision.TryGetComponent<PlayerMove>(out PlayerMove playerMove);
    
}
