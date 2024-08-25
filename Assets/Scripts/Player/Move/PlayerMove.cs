using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �������� ������
/// </summary>
public class PlayerMove : MonoBehaviour
{

    private IMoveInputService _moveInputService = new ComputerMoveInputService();
    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _direction = Vector2.zero;
    }

    private void Update()
    {
        CheckMove();
        if (_direction != Vector2.zero) Move();
    }

    /// <summary>
    /// �������� ����
    /// </summary>
    private void CheckMove()
    {
        if (_moveInputService.MoveLeft) _direction = new Vector2(-1, 0);
        if (_moveInputService.MoveRight) _direction = new Vector2(1, 0);
        if (_moveInputService.MoveUp) _direction = new Vector2(0, 1);
        if (_moveInputService.MoveDown) _direction = new Vector2(0, -1);
    }

    /// <summary>
    /// �������� ������
    /// </summary>
    private void Move()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _direction);
        // Debug.Log("Move Step Completed");
        _direction = Vector2.zero;
    }
}
