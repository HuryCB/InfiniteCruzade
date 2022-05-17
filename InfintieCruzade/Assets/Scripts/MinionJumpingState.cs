using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionJumpingState : StateMachine
{
    public Minion minion;
    // public float enteredTime;
    // public float exitTime;

    public float jumpTimeDuration = 0.5f;
    public float jumpTimeCounter = 0;
    public override void EnterState(GameObject minion)
    {

        this.minion = minion.GetComponent<Minion>();
        // this.minion.rb.AddForce(new Vector2(0, this.minion.jumpHigh), ForceMode2D.Force);
        jumpTimeDuration = this.minion.jumpTimeDuration;
        jumpTimeCounter = jumpTimeDuration;
        // //  Debug.Log("Jumping state");
        // enteredTime = Time.deltaTime;
    }


    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("fallBox"))
        {
            // Debug.Log("fallBox");
            minion.SwitchState(minion.fallingState);
        }
    }

    public override void ExitState()
    {


    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
    }

    public override void Update()
    {   // this.minion.rb.AddForce(new Vector2(0, this.minion.jumpHigh), ForceMode2D.Force);
        if (minion.rb.velocity.y < 0)
        {
            minion.SwitchState(minion.fallingState);
        }
    }

    public override void FixedUpdate()
    {
        jumpTimeCounter -= Time.deltaTime;
        // exitTime = Time.deltaTime;

        // Debug.Log("Entered " + enteredTime.ToString());
        // Debug.Log("Exited " + exitTime.ToString());
        // Debug.Log("jumpTime " + jumpTimeDuration.ToString());
        // if (exitTime - enteredTime < jumpTimeDuration)
        if (jumpTimeCounter > 0)
            this.minion.rb.velocity = new Vector2(this.minion.rb.velocity.x, this.minion.jumpHigh * Time.deltaTime);

    }

    public override void OnTriggerStay2D(Collider2D other)
    {
        
    }
}
