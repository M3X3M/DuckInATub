using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject dropEnemyPrefab;
    [SerializeField] private float max_interval;
    [SerializeField] private float start_interval;
    [SerializeField] private float cur_interval;
    public bool produce = false;

    void Start()
    {
        StartCoroutine(ExpandingSpawnTick());
        StartCoroutine(EnemySpawnIncreaser());
    }

    public void ResetSpawner()
    {
        cur_interval = start_interval;
        produce = true;
    }

    IEnumerator ExpandingSpawnTick()
    {
        while (true)
        {
            yield return new WaitForSeconds(cur_interval);

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

    IEnumerator EnemySpawnIncreaser()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);

            if(produce && (cur_interval > max_interval))
                cur_interval -= 0.05f;
        }
    }
}
