using UnityEngine;

namespace Game.Effects
{
    /// <summary>
    /// Эффект кровотечения
    /// </summary>

    public class ВleedingEffect : BaseEffects
    {
        [Tooltip("Урон за ход")]
        [SerializeField] private float _damage;

        private Health _health = null;

        public override void Awake()
        {
            _effectType = EffectType.ВleedingEffect; // устанавливаем тип эффекта - кровотечение
            _health = GetComponent<Health>(); // получаем здоровье
            if (_health == null) Destroy(this); // если его нет, то удаляем

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
            if (int.TryParse(values[0], out int moves) && int.TryParse(values[1], out int damage))
            {
                _movesEffect = moves; // устанавливаем количество ходов
                _damage = damage; // и урон
            }
            else Destroy(this);
        }

        /// <summary>
        /// Выполнение эффекта кровотечения
        /// </summary>
        public override void ExecuteEffect()
        {
            _health?.ChangeHealth(-1 * _damage);
            _currentMoves++;
            if (_currentMoves == _movesEffect) DoEffectAfterCompleted();
        }

        /// <summary>
        /// Выполняем в конце, когда прошли все ходы
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
                $"Урон за ход: {-1 * _damage}<br>" +
                $"Осталось ходов: {MovesLeft}";
            return description;
        }
    }
}