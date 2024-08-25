using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��������� ��� ������ � ��������� ������������
/// </summary>
public interface IMoveInputService {
    public bool MoveLeft { get; } // �������� �����
    public bool MoveRight { get; } // �������� ������
    public bool MoveUp { get; } // �������� �����
    public bool MoveDown { get; } // �������� ����
}
