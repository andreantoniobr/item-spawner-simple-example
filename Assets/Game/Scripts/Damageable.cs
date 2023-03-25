using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public event Action DeathEvent;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            KillDamageable();
        }
    }

    private void KillDamageable()
    {
        DeathEvent!.Invoke();
    }
}
