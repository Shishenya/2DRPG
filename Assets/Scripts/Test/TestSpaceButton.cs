using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpaceButton : MonoBehaviour
{
    public Health health;
    public CreatureEffects creatureEffects;
    public Fatigue fatigue;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            TestPlayerEffect();
    }

    /// <summary>
    /// ������������ ������� �� ������
    /// </summary>
    public void TestPlayerEffect()
    {
        �leedingEffect �leedingEffect = new �leedingEffect(4, 0, health, -5);
        creatureEffects.AddEffect(�leedingEffect);

        RecoveryFatigueEffect recoveryFatigueEffect = new RecoveryFatigueEffect(10,0,fatigue, 2, 5f);
        creatureEffects.AddEffect(recoveryFatigueEffect);
    }

}
