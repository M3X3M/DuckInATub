using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    [SerializeField] private float spawn_interval;
    [SerializeField] private Vector2 LimitBottomLeft, LimitTopRight;
    [SerializeField] private float spawn_y;
    [SerializeField] private GameObject expandingBubblePrefab;

    void Start()
    {
        return;
        StartCoroutine(SpawnTick());
    }

    IEnumerator SpawnTick()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawn_interval);

            SpawnExpandingBubble();
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
}
