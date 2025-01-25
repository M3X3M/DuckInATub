using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    [SerializeField] private float expanding_spawn_interval, moving_spawn_interval;
    [SerializeField] private Vector2 LimitBottomLeft, LimitTopRight;
    [SerializeField] private float spawn_y;
    [SerializeField] private GameObject expandingBubblePrefab, movingBubblePrefab;

    void Start()
    {
        StartCoroutine(ExpandingSpawnTick());
        StartCoroutine(MovingSpawnTick());
    }

    IEnumerator ExpandingSpawnTick()
    {
        while (true)
        {
            yield return new WaitForSeconds(expanding_spawn_interval);

            SpawnExpandingBubble();
        }
    }

    IEnumerator MovingSpawnTick()
    {
        while (true)
        {
            yield return new WaitForSeconds(moving_spawn_interval);

            SpawnMovingBubble();
        }
    }

    private void SpawnExpandingBubble()
    {
        Vector3 spawn_pos = new Vector3(
            Random.Range(LimitBottomLeft.x, LimitTopRight.x),
            spawn_y,
            Random.Range(LimitBottomLeft.y, LimitTopRight.y)
        );
        Quaternion spawn_rotation = Quaternion.identity;

        GameObject instance = Instantiate(
            expandingBubblePrefab,
            spawn_pos,
            spawn_rotation
        );
    }

    private void SpawnMovingBubble()
    {
        GameObject instance = Instantiate(
            movingBubblePrefab
        );
    }
}
