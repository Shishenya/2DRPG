using UnityEngine;

namespace Game.Effects
{
    /// <summary>
    /// Эффект восстановления здоровья
    /// </summary>
    public class RecoveryHealthEffect : BaseEffects
    {

        [Tooltip("Восстановление за ход")]
        [SerializeField] private float _stepIncrement;

        [Tooltip("Восстановление в начале использования")]
        [SerializeField] private float _startIncrement;

        [Tooltip("Восстановление в конце хода")]
        [SerializeField] private float _endIncrement;

        private Health _health = null;

        public override void Awake()
        {
            _effectType = EffectType.RecoveryHealth; // устанавливаем тип эффекта - восстановление здоровья
            _health = GetComponent<Health>(); // получаем здоровье
            if (_health == null) Destroy(this); // если его нет, то удаляем

            base.Awake(); // получаем шаги

            _step.CompleteStepEvent += ExecuteEffect; // подписываемся
            _creatureEffects.AddEffect(this); // добавляем эффект в список

            if (_startIncrement != 0) DoEffectAfterStart();

        }

        /// <summary>
        /// Выполнение эффекта восстановления здоровья
        /// </summary>
        public override void ExecuteEffect()
        {
            _health?.ChangeHealth(_stepIncrement);
            _currentMoves++;
            if (_currentMoves == _movesEffect) DoEffectAfterCompleted();
        }

        /// <summary>
        /// Выполняем в конце, когда прошли все ходы
        /// </summary>
        public override void DoEffectAfterCompleted()
        {
            _health?.ChangeHealth(_endIncrement);
            _creatureEffects.RemoveEffect(this);
            _step.CompleteStepEvent -= ExecuteEffect;
            Destroy(this);
        }

        public override void DoEffectAfterStart()
        {
            _health?.ChangeHealth(_startIncrement);
            if (MovesLeft == 0) DoEffectAfterCompleted();
        }

        /// <summary>
        /// Установка стандартных параметров по ходам
        /// </summary>
        public override void SetBaseValue(string[] values)
        {
            if (values.Length != 4) Destroy(this); // если не двух параметров, то выходим
            if (int.TryParse(values[0], out int moves) 
                && int.TryParse(values[1], out int stepvalue) 
                && int.TryParse(values[2], out int startValue)
                && int.TryParse(values[3], out int endValue))
            {
                _movesEffect = moves; // устанавливаем количество ходов
                _stepIncrement = stepvalue; // восстановление в ход
                _startIncrement = startValue; // восстановление в начале
                _endIncrement = endValue; // в конце хода
            }
            else Destroy(this);
        }

        /// <summary>
        /// Возвращает описание эффекта
        /// </summary>
        public override string GetDescription()
        {
            string description = $"<b>{_effectInGame_SO.Title}</b>.<br>" +
                $"{_effectInGame_SO.Description}<br>" +
                $"Восстанавливает за ход: { _stepIncrement}<br>" +
                $"Осталось ходов: {MovesLeft}";
            return description;
        }
    }
}