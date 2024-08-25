using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Проверка возможности движения
/// </summary>
public class CanBeMove
{

    private Transform _transform = null;
    private float _distance = 1f;
    private LayerMask _layerMask;
    private float _radius = 0.5f;

    public CanBeMove(Transform transform, float distance, LayerMask layerMask)
    {
        _transform = transform;
        _distance = distance;
        _layerMask = layerMask;
    }

    /// <summary>
    /// Проверка возожности движения
    /// </summary>
    public bool CanMove(MoveDirection moveDirection)
    {
        // Начальная позиция (позиция объекта)
        Vector2 origin = GetOriginByDirection(moveDirection);
        //Vector2 origin = _transform.position;

        // Определяем направление
        Vector2 direction = GetVectorByDirection(moveDirection);

        if (direction == Vector2.zero) return false;

        // Переменная для хранения информации о столкновении
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, _distance, _layerMask);

        // Проверка на столкновение
        if (hit.collider != null)
        {
            //Debug.Log("Столкновение с объектом: " + hit.collider.name);
            //Debug.Log($"{moveDirection}:  {origin}");
            return false;
        }
        else
        {
            //Debug.Log("Нет столкновения.");
            //Debug.Log($"{moveDirection}:  {origin}");
            return true;
        }
    }

    /// <summary>
    /// Получение точки отсчета вектора
    /// </summary>
    private Vector2 GetOriginByDirection(MoveDirection moveDirection)
    {
        switch (moveDirection)
        {
            case MoveDirection.MoveLeft:
                return (Vector2)_transform.position + new Vector2(-1* _radius, 0f);
            case MoveDirection.MoveRight:
                return (Vector2)_transform.position + new Vector2(_radius, 0f);
            case MoveDirection.MoveUp:
                return (Vector2)_transform.position + new Vector2(0f, _radius);               
            case MoveDirection.MoveDown:
                return (Vector2)_transform.position + new Vector2(0f, -1 * _radius);                              
            default:
                return Vector2.zero;
        }
    }

    /// <summary>
    /// Получение вектора движения
    /// </summary>
    private Vector2 GetVectorByDirection(MoveDirection moveDirection)
    {
        switch (moveDirection)
        {
            case MoveDirection.MoveLeft:
                return Vector2.left;
            case MoveDirection.MoveRight:
                return Vector2.right;
            case MoveDirection.MoveUp:
                return Vector2.up;
            case MoveDirection.MoveDown:
                return Vector2.down;
            default:
                return Vector2.zero;
        }
    }

}

/// <summary>
/// Направления движения
/// </summary>
public enum MoveDirection
{
    MoveLeft,
    MoveRight,
    MoveUp,
    MoveDown,
}
