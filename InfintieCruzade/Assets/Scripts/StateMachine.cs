using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine
{
 
    public abstract void EnterState(GameObject gm);
    public abstract void ExitState();

    public abstract void Update();

    public abstract void OnTriggerEnter2D(Collider2D other);

    public abstract void OnCollisionEnter2D(Collision2D collision);
    // public abstract void  OnTriggerStay2D(Collider2D other);
        
}
