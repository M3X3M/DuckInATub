using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform boyeTR, boyeTL, boyeBR, boyeBL;
    [SerializeField] private float rotation_speed, movement_speed;

    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target_pos;

        if (Input.GetButton("TopLeft"))
        {
            target_pos = boyeTL.position - transform.position;
        }
        else if (Input.GetButton("TopRight"))
        {
            target_pos = boyeTR.position - transform.position;
        }
        else if (Input.GetButton("BottomLeft"))
        {
            target_pos = boyeBL.position - transform.position;
        }
        else if (Input.GetButton("BottomRight"))
        {
            target_pos = boyeBR.position - transform.position;
        }
        else
        {
            animator.SetBool("IsMoving", false);
            return;
        }

        animator.SetBool("IsMoving", true);

        float target_angle = Mathf.Atan2(target_pos.x, target_pos.z) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, target_angle, 0));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotation_speed * Time.deltaTime);
        transform.position += movement_speed * Time.deltaTime * transform.forward;
    }
}
