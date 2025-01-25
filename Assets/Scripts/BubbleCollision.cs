using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BubbleBase))]
public class BubbleCollision : MonoBehaviour
{
    private ScoreMaster scoreMaster;
    private BubbleBase bubble_base;


    void Start()
    {
        scoreMaster = GameObject.Find("GameMaster").GetComponent<ScoreMaster>();

        if (scoreMaster == null)
        {
            Debug.LogError("No ScoreMaster found");
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            return;
        }

        scoreMaster.AddScore(1);
        bubble_base.Pop();
    }
}
