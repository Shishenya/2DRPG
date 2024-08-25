using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���������� �� ����������
/// </summary>
public class ComputerMoveInputService : IMoveInputService
{
    public bool MoveDown =>
        Input.GetKeyUp(KeyCode.S);

    public bool MoveLeft =>
        Input.GetKeyUp(KeyCode.A);


    public bool MoveRight=>    
        Input.GetKeyUp(KeyCode.D);
    
    public bool MoveUp =>    
        Input.GetKeyUp(KeyCode.W);    
}