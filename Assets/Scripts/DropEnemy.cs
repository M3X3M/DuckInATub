using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DropEnemy : MonoBehaviour
{
    [SerializeField] private float wait_time = 4f;
    [SerializeField] private float start_height = 10f;
    [SerializeField] private Transform mark;

    private Transform _water;
    private Animator _animator;
    private bool update_mark = false;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        Vector2 pos = GameObject.Find("GameMaster").GetComponent<GameInfo>().GetRandomPositions();
        _water = GameObject.FindWithTag("Water").transform;
        transform.position = new Vector3(
            pos.x,
            start_height,
            pos.y
        );

        mark.position = new Vector3(
            transform.position.x,
            _water.transform.position.y + 0.01f,
            transform.position.z
        );
        StartCoroutine(DropTimer());
    }

    void Update()
    {
        if(update_mark == true)
        {
            mark.position = new Vector3(
                transform.position.x,
                _water.transform.position.y + 0.01f,
                transform.position.z
            );
        }
    }

    private void DeleteMark()
    {
        update_mark = false;
        Destroy(mark.gameObject);
    }

    IEnumerator DropTimer()
    {
        yield return new WaitForSeconds(wait_time);

        update_mark = true;
        GetComponentInChildren<Rigidbody>().isKinematic = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            GetComponent<Collider>().enabled = false;
            DeleteMark();
            GetComponentInChildren<Rigidbody>().isKinematic = true;
            _animator.SetTrigger("DoFloat");
        }
    }

    public void OnDrownDone()
    {
        Destroy(gameObject);
    }
}
