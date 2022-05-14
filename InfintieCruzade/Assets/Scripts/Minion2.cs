// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Minion2 : MonoBehaviour
// {
//     [SerializeField] private float speed = 2f;
//     [SerializeField] private float jumpHigh = 200f;

//     Rigidbody2D rb;
//     public bool grounded;

//     public float willJumpAtPos;

//     public bool hasPartyJumped = false;

//     void Start()
//     {
//         rb = GetComponent<Rigidbody2D>();
//     }

//     void Update()
//     {
//         //jump();
//         groupJump();
//     }

//     private void groupJump()
//     {
//         if (this.transform.position.x >= willJumpAtPos - 0.5 && this.transform.position.x <= willJumpAtPos + 0.5)
//         {
//             if (grounded && !hasPartyJumped)
//             {
//                 rb.AddForce(new Vector2(0, jumpHigh), ForceMode2D.Force);
//                 hasPartyJumped = true;
//                 // Debug.Log("groundedJump");
//             }

//         }
//     }

//     public bool jump()
//     {
//         if (!grounded)
//         {
//             return false;
//         }
//         bool willJump = checkJumpInput();
//         if (!willJump)
//         {
//             return false;
//         }
//         willJumpAtPos = transform.position.x;
//         rb.AddForce(new Vector2(0, jumpHigh), ForceMode2D.Force);
//         Debug.Log("jump");
//         return true;
//         //rb.velocity = new Vector2(rb.velocity.x, 10);
//     }

//     private bool checkJumpInput()
//     {
//         if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
//         {
//             return true;
//         }
//         if (Input.GetMouseButtonUp(0) || Input.GetKeyDown(KeyCode.Space))
//         {
//             return true;
//         }
//         return false;
//     }

//     private void FixedUpdate()
//     {
//         //rb.AddForce(transform.right*speed);
//         rb.velocity = new Vector2(speed, rb.velocity.y);
//     }

//     private void OnCollisionEnter2D(Collision2D collision)
//     {
//         if (collision.gameObject.tag == "ground")
//         {
//             grounded = true;
//         }
//     }

//     private void OnTriggerStay2D(Collider2D other)
//     {
//         if (other.CompareTag("collectable"))
//         {

//         }
//     }
//     private void OnCollisionExit2D(Collision2D collision)
//     {
//         if (collision.gameObject.tag == "ground")
//         {
//             grounded = false;
//         }
//     }
// }
