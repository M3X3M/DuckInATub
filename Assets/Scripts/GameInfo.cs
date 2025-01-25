using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    private Vector2 _cam_sizes;

    // Start is called before the first frame update
    void Start()
    {
        CalculateCameraSizes();
    }

    private void CalculateCameraSizes()
    {
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        _cam_sizes = new Vector2(width, height);
    }

    public Vector2 GetCameraSizes()
    {
        return _cam_sizes;
    }
}
