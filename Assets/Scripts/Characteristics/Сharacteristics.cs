using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Характеристики существа
/// </summary>
[System.Serializable]
public class Сharacteristics
{

    private int _strength; // Сила
    public int Strength { get => _strength; }

    private int _stamina; // Выносливость
    public int Stamina { get => _stamina; }

    private int _agility; // Ловкость
    public int Agility { get => _agility; }

    private int _attention; // Внимательность
    public int Attention { get => _attention; }

    public Сharacteristics(int strength, int stamina, int agility, int attention)
    {
        _strength = strength;
        _stamina = stamina;
        _agility = agility;
        _attention = attention;
    }


}
