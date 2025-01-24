using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleCollision : MonoBehaviour
{
    private ScoreMaster scoreMaster;


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
        Destroy(gameObject);
    }
}
