using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    [SerializeField] private Vector2 field_size;
    [SerializeField] private float vertical_offset;


    public Vector2 GetFieldSize()
    {
        return field_size;
    }

    public float GetVerticalOffset()
    {
        return vertical_offset;
    }

    public Vector2 GetRandomPositions()
    {
        return new Vector2(
            Random.Range(-field_size.x, field_size.x),
            Random.Range(-field_size.y + vertical_offset , field_size.y + vertical_offset)
        );
    }
}
