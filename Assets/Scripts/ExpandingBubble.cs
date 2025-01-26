using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BubbleBase))]
public class ExpandingBubble : MonoBehaviour
{
    [SerializeField] private float start_size_min, start_size_max;
    [SerializeField] private float end_size_min, end_size_max;
    [SerializeField] private float duration_min, duration_max;

    private Vector3 start_size;
    private Vector3 end_size;
    private float duration;
    private float elapsed_time = 0f;
    private BubbleBase bubble_base;

    // Start is called before the first frame update
    void Start()
    {
        bubble_base = GetComponent<BubbleBase>();
        start_size = Random.Range(start_size_min, start_size_max) * Vector3.one;
        end_size = Random.Range(end_size_min, end_size_max) * Vector3.one;
        duration = Random.Range(duration_min, duration_max);
        transform.localScale = start_size;
    }

    // Update is called once per frame
    void Update()
    {
        if (elapsed_time < duration)
        {
            elapsed_time += Time.deltaTime;
            float t = elapsed_time / duration;
            transform.localScale = Vector3.Lerp(start_size, end_size, t);
        }
        else
        {
            bubble_base.Pop();
        }
    }
}
