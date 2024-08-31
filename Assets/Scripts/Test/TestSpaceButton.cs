using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpaceButton : MonoBehaviour
{
    public Health health;
    public CreatureEffects creatureEffects;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            TestPlayerEffect();
    }

    /// <summary>
    /// Òåñòèğîâàíèå ıôôåêòà íà èãğîêå
    /// </summary>
    public void TestPlayerEffect()
    {
        ÂleedingEffect âleedingEffect = new ÂleedingEffect(4, 0, health, -5);
        creatureEffects.AddEffect(âleedingEffect);
    }

}
