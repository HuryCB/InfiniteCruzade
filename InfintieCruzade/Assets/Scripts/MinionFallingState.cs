using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionFallingState : StateMachine
{
    public Minion minion;

    public float fallGravity = 0;
    public override void EnterState(GameObject gm)
    {
        this.minion = gm.GetComponent<Minion>();
        fallGravity = minion.fallGravity;
        // Debug.Log("falling");

    }

    public override void ExitState()
    {

    }

    public override void FixedUpdate()
    {
        // this.minion.rb.velocity = new Vector2(this.minion.rb.velocity.x, -1 * Time.deltaTime);
         minion.rb.AddForce(Vector2.down * minion.rb.gravityScale * fallGravity * minion.rb.mass);
   

    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            minion.SwitchState(minion.runningState);
        }
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {

    }

    public override void Update()
    {

    }
}
