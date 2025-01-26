using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    [SerializeField] private float expanding_spawn_interval, moving_spawn_interval;
    [SerializeField] private float spawn_y;
    [SerializeField] private GameObject expandingBubblePrefab, movingBubblePrefab;
    private GameInfo gameInfo;
    public bool produce = false;


    void Start()
    {
        gameInfo = GameObject.Find("GameMaster").GetComponent<GameInfo>();
        if (expanding_spawn_interval > 0.0f)
            StartCoroutine(ExpandingSpawnTick());
        if (moving_spawn_interval > 0.0f)
            StartCoroutine(MovingSpawnTick());
    }

    IEnumerator ExpandingSpawnTick()
    {
        while (true)
        {
            yield return new WaitForSeconds(expanding_spawn_interval);

            if(produce)
                SpawnExpandingBubble();
        }
    }

    IEnumerator MovingSpawnTick()
    {
        while (true)
        {
            yield return new WaitForSeconds(moving_spawn_interval);

            if(produce)
                SpawnMovingBubble();
        }
    }

    private void SpawnExpandingBubble()
    {
        Vector2 random_pos = gameInfo.GetRandomPositions();
        Vector3 spawn_pos = new Vector3(
            random_pos.x,
            spawn_y,
            random_pos.y
        );
        Quaternion spawn_rotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));

        GameObject instance = Instantiate(
            expandingBubblePrefab,
            spawn_pos,
            spawn_rotation
        );
        instance.transform.parent = transform;
    }

    private void SpawnMovingBubble()
    {
        GameObject instance = Instantiate(
            movingBubblePrefab
        );
        instance.transform.parent = transform;
    }
}
