using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Effects;

public class TestSpaceButton : MonoBehaviour
{
    public GameObject player;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Exec();
    }

    private void Exec()
    {
        string[] valuesÂleedingEffect = { "5", "10" };
        string[] valuesRecoveryFatigue = { "10", "2" };
        ApplyEffect.Instance.Apply(player, EffectType.ÂleedingEffect, valuesÂleedingEffect);
        ApplyEffect.Instance.Apply(player, EffectType.RecoveryFatigue, valuesRecoveryFatigue);
    }
}
