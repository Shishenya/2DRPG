using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Интерфейс для работы с движением пользователя
/// </summary>
public interface IMoveInputService {
    public bool MoveLeft { get; } // движение влево
    public bool MoveRight { get; } // движение вправо
    public bool MoveUp { get; } // движение вверх
    public bool MoveDown { get; } // движение вниз
}
