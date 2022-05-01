using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PartyManager : MonoBehaviour
{
    public static PartyManager instance;
    [SerializeField] public List<Minion> party = new List<Minion>();

    [SerializeField] Minion firstMinion;

    public GameObject jumpBox;
    public GameObject minion;

    private void Awake() 
{ 
    // If there is an instance, and it's not me, delete myself.
    
    if (instance != null && instance != this) 
    { 
        Destroy(this); 
    } 
    else 
    { 
        instance = this; 
    } 
}

    public Minion getFirstMinion()
    {
        return this.firstMinion;
    }

    // Update is called once per frame
    void Update()
    {
        verifyFirstMinion();
        partyJump();
    }

    private void partyJump()
    {
        if (!checkJumpInput())
        {
            return;
        }
        // Debug.Log("deveria pular");
        foreach (Minion minion in party)
        {
            if (minion.grounded && minion.rb.velocity.y >= 0)
            {
                Instantiate(jumpBox, minion.transform.position, Quaternion.identity);
                break;
            }
        }

        // firstMinion.jump();
    }

    private void verifyFirstMinion()
    {
        // List<Minion> newParty = new List<Minion>(party);
        party = party.OrderByDescending(minion => minion.transform.position.x).ToList();
        firstMinion = party[0];
        // foreach (Minion minion in party){
        //     minion.isFirstMinion = false;
        // }
        // party[0].isFirstMinion = true;



        // foreach (Minion minion in party)
        // {
        //     if (minion.transform.position.x > firstMinion.transform.position.x)
        //     {
        //         firstMinion.isFirstMinion = false;
        //         firstMinion = minion;
        //         firstMinion.isFirstMinion = true;

        //     }
        // }
    }

    private bool checkJumpInput()
    {
        bool input = (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonUp(0) || Input.GetKeyDown(KeyCode.Space);

        if (!input)
        {
            return false;
        }
        // Debug.Log("teste");

        return true;
    }
}
