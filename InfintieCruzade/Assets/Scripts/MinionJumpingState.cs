using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionJumpingState : StateMachine
{
    public Minion minion;
    public override void EnterState(GameObject minion)
    {
       
        this.minion = minion.GetComponent<Minion>();
        this.minion.rb.AddForce(new Vector2(0, this.minion.jumpHigh), ForceMode2D.Force);
        //  Debug.Log("Jumping state");
    }


    public override void OnTriggerEnter2D(Collider2D other)
    {

    }

    public override void ExitState()
    {


    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            minion.SwitchState(minion.runningState);
        }
    }

    public override void Update()
    {

    }
}
