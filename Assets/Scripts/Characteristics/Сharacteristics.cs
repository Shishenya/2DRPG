using UnityEngine;

namespace Game.Parameters
{
    /// <summary>
    /// Характеристики существа
    /// </summary>
    [System.Serializable]
    public class Сharacteristics
    {
        [Tooltip("Сила")]
        [SerializeField] private int _strength; // Сила
        public int Strength { get => _strength; }

        [Tooltip("Выносливость")]
        [SerializeField] private int _stamina; // Выносливость
        public int Stamina { get => _stamina; }

        [Tooltip("Ловкость")]
        [SerializeField] private int _agility; // Ловкость
        public int Agility { get => _agility; }

        [Tooltip("Внимательность")]
        [SerializeField] private int _attention; // Внимательность
        public int Attention { get => _attention; }

        public Сharacteristics(int strength, int stamina, int agility, int attention)
        {
            _strength = strength;
            _stamina = stamina;
            _agility = agility;
            _attention = attention;
        }


    }
}
