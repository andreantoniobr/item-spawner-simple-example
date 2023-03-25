using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DropItem
{
    public Item ItemToSpawn;
    [Range(0f, 1f)]
    public float ItemDropPercent;
}

[RequireComponent(typeof(Damageable))]
public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private DropItem[] dropItem;
    [SerializeField] private Damageable damageable;
    [SerializeField] private float itemPositionY = 1.5f;
    [SerializeField] private float itemPositionSpawnerRange = 1.5f;


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
            damageable.DeathEvent += OnDeath;
        }
    }

    private void UnsbcribeInEvents()
    {
        if (damageable)
        {
            damageable.DeathEvent -= OnDeath;
        }
    }
    

    private void GetDamageable()
    {
        if (!damageable)
        {
            damageable = GetComponent<Damageable>();
        }
    }   

    private void OnDeath()
    {
        for (int i = 0; i < dropItem.Length; i++)
        {
            DropItem currentDropItem = dropItem[i];
            if (currentDropItem != null)
            {
                RandomDropItem(currentDropItem);
            }
        }
    }

    private void RandomDropItem(DropItem dropItem)
    {
        if (dropItem != null)
        {
            float dropItemPercent = Random.Range(0f, 1f);
            Debug.Log(dropItemPercent);
            if (dropItemPercent <= dropItem.ItemDropPercent)
            {
                SpawnItem(dropItem.ItemToSpawn);
            }
        }        
    }

    private void SpawnItem(Item item)
    {
        if (item)
        {
            Item currentItem = Instantiate(item, GetItemPosition(), Quaternion.identity);
        }
    }

    private Vector3 GetItemPosition()
    {
        float itemPositionRandomRangeX = Random.Range(-itemPositionSpawnerRange, itemPositionSpawnerRange);
        float itemPositionRandomRangeZ = Random.Range(-itemPositionSpawnerRange, itemPositionSpawnerRange);
        Vector3 position = new Vector3(itemPositionRandomRangeX, itemPositionY, itemPositionRandomRangeZ);
        return transform.position + position;
    }
}
