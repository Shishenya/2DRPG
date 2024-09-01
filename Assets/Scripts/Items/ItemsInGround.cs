using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Предметы, которые лежат на земле
/// </summary>
public class ItemsInGround : MonoBehaviour
{
    private Items _items; // предметы, которые лежат на земле
    private SpriteRenderer _spriteRenderer; // Спрайт для предметов на земле

    private void Awake()
    {
        _items = GetComponent<Items>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        CreateIcon(); // создание иконки для предметов на земле
    }

    /// <summary>
    /// Создание иконки для предмета на земле
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
    /// Вошли в коллайдер
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsPlayer(collision)) return;
        Debug.Log("Вошли в коллайдер");
        ItemsInGroundCanvas.Instance.Init(_items);
    }

    /// <summary>
    /// Вышли из него
    /// </summary>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!IsPlayer(collision)) return;
        ItemsInGroundCanvas.Instance.ReInit();
        Debug.Log("Вышли из него");
    }

    /// <summary>
    /// Проверка на игрока
    /// </summary>
    private bool IsPlayer(Collider2D collision) =>    
        collision.TryGetComponent<PlayerMove>(out PlayerMove playerMove);
    
}
