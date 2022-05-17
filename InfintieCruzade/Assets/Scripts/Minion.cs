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
    public float jumpTimeDuration = 0.5f;

    public StateMachine currentState;
    public MinionRunningState runningState = new MinionRunningState();

    public MinionJumpingState jumpingState = new MinionJumpingState();
    public MinionFallingState fallingState = new MinionFallingState();

    public float fallGravity = 10;

    public int worlds = 1;


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
        currentState.FixedUpdate();
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
            Minion minion =Instantiate(PartyManager.instance.minion,party[party.Count-1].transform.position-new Vector3(0.5f,0,0), Quaternion.identity).GetComponent<Minion>();
            party.Add(minion);
            minion.currentState = this.currentState;
        }
        if(other.gameObject.CompareTag("flag")){
            Debug.Log("Colidiu");
            Destroy(other.gameObject);
            Vector3 pos = new Vector3(worlds*30, 0f, transform.position.z);
            Instantiate(WorldGeneration.instance.worlds[0], pos, Quaternion.identity);
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
        rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
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

        rb.velocity = Vector2.up * jumpHigh * Time.deltaTime;
        // rb.AddForce(new Vector2(0, jumpHigh), ForceMode2D.Force);
        return true;
    }
}
