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
        string[] values = { "5", "10" };
        ApplyEffect.Instance.Apply(player, EffectType.ÂleedingEffect, values);
    }
}
