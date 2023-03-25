using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Damageable))]
public class NpcDespawner : MonoBehaviour
{
    private Damageable damageable;

    private void Awake()
    {
        GetDamageable();
        SubscribeInEvents();
    }

    private void OnDestroy()
    {
        UnsbcribeInEvents();
    }

    private void OnValidate()
    {
        GetDamageable();
    }

    private void SubscribeInEvents()
    {
        if (damageable)
        {
            damageable.DeathEvent += Despawn;
        }
    }

    private void UnsbcribeInEvents()
    {
        if (damageable)
        {
            damageable.DeathEvent -= Despawn;
        }
    }

    private void GetDamageable()
    {
        if (!damageable)
        {
            damageable = GetComponent<Damageable>();
        }
    }

    private void Despawn()
    {
        Destroy(gameObject);
    }
}
