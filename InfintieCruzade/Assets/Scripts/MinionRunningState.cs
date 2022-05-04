using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionRunningState : StateMachine
{
    public Minion minion;



    public override void EnterState(GameObject minion)
    {

        this.minion = minion.GetComponent<Minion>();

        // Debug.Log("Running state");
    }


    public override void ExitState()
    {

    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("jumpBox"))
        {
            if (!minion.grounded)
            {
                return;
            }
            minion.SwitchState(minion.jumpingState);
        }
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {

    }
    public override void Update()
    {

        // Debug.Log("sucesso");
    }

    public override void FixedUpdate()
    {
    }
}
