using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnController : MonoBehaviour
{
    [SerializeField] private Transform player;

    void Start()
    {
        //Initially setting this as a reference
        transform.position = player.position;
    }
}
