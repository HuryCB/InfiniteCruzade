using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingGround : MonoBehaviour
{
    public bool hasFallen = false;
    public Animator animator;
    private void OnCollisionEnter2D(Collision2D collision)
    {

        // currentState.OnCollisionEnter2D(collision);
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!hasFallen)
            {
                hasFallen = true;
                fall();
                // Invoke("fall",1);
            }
            // grounded = true;
        }
    }

    private void fall()
    {
        animator.SetTrigger("fall");
        // transform.position = new Vector3(transform.position.x, transform.position.y - 2, 0);

    }
}
