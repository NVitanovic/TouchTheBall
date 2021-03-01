using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            // Sneak animation
            animator.SetBool("isSneaking", true);
            animator.SetBool("isWalking", false);

            // Move the player twice slower
            transform.Translate(Vector3.forward * 2 * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.W))
        {
            // Walk
            animator.SetBool("isSneaking", false);
            animator.SetBool("isWalking", true);

            // Move the player forward
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
        else
        {
            // Stop all animations
            animator.SetBool("isWalking", false);
            animator.SetBool("isSneaking", false);
        }
        // Rotation
        if (Input.GetKey(KeyCode.A))
        {
            // Rotate the player left
            transform.Rotate(Vector3.down * 50 * Time.deltaTime, Space.Self);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // Rotate the player right
            transform.Rotate(Vector3.up * 50 * Time.deltaTime, Space.Self);
        }
    }
}
