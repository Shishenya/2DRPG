using UnityEngine;

namespace Game.Effects
{
    /// <summary>
    /// Эффект восстановление усталости
    /// </summary>
    public class RecoveryFatigueEffect : BaseEffects
    {
        [Tooltip("Сколько восстанавливает энергии?")]
        [SerializeField] private int _valueIncrement;

        private Fatigue _fatigue = null; // Усталость

        public override void Awake()
        {
            _effectType = EffectType.RecoveryFatigue; // устанавливаем тип эффекта - восстановление энергии
            _fatigue = GetComponent<Fatigue>(); // получаем энергию
            if (_fatigue == null) Destroy(this); // если его нет, то удаляем

            base.Awake(); // получаем шаги

            _step.CompleteStepEvent += ExecuteEffect; // подписываемся
            _creatureEffects.AddEffect(this); // добавляем эффект в список
        }

        /// <summary>
        /// Установка стандартных параметров по ходам
        /// </summary>
        public override void SetBaseValue(string[] values)
        {
            if (values.Length != 2) Destroy(this); // если не двух параметров, то выходим
            if (int.TryParse(values[0], out int moves) && int.TryParse(values[1], out int increment))
            {
                _movesEffect = moves; // устанавливаем количество ходов
                _valueIncrement = increment; // и урон
            }
            else Destroy(this);
        }

        /// <summary>
        /// Выполнение эффекта восстановления энергии
        /// </summary>
        public override void ExecuteEffect()
        {
            _fatigue?.ChangeFatigue(_valueIncrement);
            _currentMoves++;
            if (_currentMoves == _movesEffect) DoEffectAfterCompleted();
        }

        /// <summary>
        /// Завершение эффекта
        /// </summary>
        public override void DoEffectAfterCompleted()
        {
            _creatureEffects.RemoveEffect(this);
            _step.CompleteStepEvent -= ExecuteEffect;
            Destroy(this);
        }

        /// <summary>
        /// Возвращает описание эффекта
        /// </summary>
        public override string GetDescription()
        {
            string description = $"<b>{_effectInGame_SO.Title}</b>.<br>" +
                $"{_effectInGame_SO.Description}<br>" +
                $"Восстанавливают за ход: {_valueIncrement}.<br>" +
                $"Осталось ходов: {MovesLeft} ";
            return description;
        }
    }
}