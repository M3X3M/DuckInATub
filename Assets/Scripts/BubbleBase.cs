using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBase : MonoBehaviour
{
    public void Pop()
    {
        // TODO: make sound, and pop anim
        Destroy(gameObject);
    }
}
