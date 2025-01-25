using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject dropEnemyPrefab;
    [SerializeField] private float dropEnemyInterval = 5f;
    public bool produce = false;

    void Start()
    {
        StartCoroutine(ExpandingSpawnTick());
    }

    IEnumerator ExpandingSpawnTick()
    {
        while (true)
        {
            yield return new WaitForSeconds(dropEnemyInterval);

            if(produce)
                SpawnDropEnemy();
        }
    }

    private void SpawnDropEnemy()
    {
        GameObject instance = Instantiate(
            dropEnemyPrefab
        );
        instance.transform.parent = transform;
    }
}
