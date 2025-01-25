using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropEnemy : MonoBehaviour
{
    [SerializeField] private float wait_time = 4f;
    [SerializeField] private float start_height = 10f;
    private Vector2 _camBounds;

    // Start is called before the first frame update
    void Start()
    {
        _camBounds = GameObject.Find("GameMaster").GetComponent<GameInfo>().GetCameraSizes();
        transform.position = new Vector3(
            Random.Range(-_camBounds.x, _camBounds.x),
            start_height,
            Random.Range(-_camBounds.y, _camBounds.y)
        );
        StartCoroutine(DropTimer());
    }

    private void CreateMark()
    {

    }

    private void DeleteMark()
    {

    }

    IEnumerator DropTimer()
    {
        yield return new WaitForSeconds(wait_time);

        GetComponent<Rigidbody>().isKinematic = false;
    }
}
