using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
    [SerializeField] public float speed = 2f;
    [SerializeField] public float jumpHigh = 200f;

    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public bool grounded = true;

    public StateMachine currentState;
    public MinionRunningState runningState = new MinionRunningState();

    public MinionJumpingState jumpingState = new MinionJumpingState();

    // public bool isFirstMinion = false;

    private void Start()
    {
        currentState = runningState;
        currentState.EnterState(this.gameObject);
    }
    public void SwitchState(StateMachine state)
    {
        currentState.ExitState();
        state.EnterState(this.gameObject);
        currentState = state;

    }


    void Update()
    {
        currentState.Update();
        // if (rb.velocity.y < 0)
        // {
        //     Debug.Log("caindo");
        // }

    }

    private void FixedUpdate()
    {
        walk();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.OnCollisionEnter2D(collision);
        if (collision.gameObject.CompareTag("ground"))
        {
            grounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        currentState.OnTriggerEnter2D(other);

        if(other.CompareTag("collectable")){
            Destroy(other.gameObject);
            List<Minion>party =  PartyManager.instance.party;
            party.Add(Instantiate(PartyManager.instance.minion,party[party.Count-1].transform.position-new Vector3(0.5f,0,0), Quaternion.identity).GetComponent<Minion>());
        }
        // if (other.CompareTag("jumpBox"))
        // {
        //     //  if(isFirstMinion){
        //     //      return;
        //     //  }
        //     //  Debug.Log("jumping");
        //     jump();
        // }
        // if (other.CompareTag("fall"))
        // {
        //     jumpHigh = 0;
        // }
    }
    private void walk()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            grounded = false;
        }
    }

    public bool jump()
    {


        rb.AddForce(new Vector2(0, jumpHigh), ForceMode2D.Force);
        return true;
    }
}
