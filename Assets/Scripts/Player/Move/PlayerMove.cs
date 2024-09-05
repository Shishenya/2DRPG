using UnityEngine;
using Game.Step;

namespace Player.Move
{
    /// <summary>
    /// �������� ������
    /// </summary>
    public class PlayerMove : MonoBehaviour
    {

        [Tooltip("� ��� ��������� ������������")]
        [SerializeField] private LayerMask _layerMask; // ����� �����, ������� ����� ���������� � ����������

        private IMoveInputService _moveInputService = new ComputerMoveInputService();
        private Rigidbody2D _rigidbody2D = null;
        private Vector2 _direction;
        private PlayerStepCheck _playerStepCheck = null;
        private CanBeMove _canBeMove = null;

        private void Awake()
        {
            _canBeMove = new CanBeMove(transform, 0.9f, _layerMask);
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _direction = Vector2.zero;
            _playerStepCheck = GetComponent<PlayerStepCheck>();
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
            if (_moveInputService.MoveLeft && _canBeMove.CanMove(MoveDirection.MoveLeft)) _direction = new Vector2(-1, 0);
            if (_moveInputService.MoveRight && _canBeMove.CanMove(MoveDirection.MoveRight)) _direction = new Vector2(1, 0);
            if (_moveInputService.MoveUp && _canBeMove.CanMove(MoveDirection.MoveUp)) _direction = new Vector2(0, 1);
            if (_moveInputService.MoveDown && _canBeMove.CanMove(MoveDirection.MoveDown)) _direction = new Vector2(0, -1);
        }

        /// <summary>
        /// �������� ������
        /// </summary>
        private void Move()
        {
            _rigidbody2D.MovePosition(_rigidbody2D.position + _direction);
            // Debug.Log("Move Step Completed");
            CheckTransform();
            _direction = Vector2.zero;

            // �������� ����� ��������� ��������
            _playerStepCheck.CallCompleteStepEvent();
        }

        /// <summary>
        /// ���������� �� �������� 0.5, ����� ��?
        /// </summary>
        private void CheckTransform()
        {

        }

    }
}
