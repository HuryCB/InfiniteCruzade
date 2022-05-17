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

    public GameObject fallBox;
    public GameObject minion;

    public bool jumpPressed = false;
    public bool jumpDown = false;

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
        if(PauseControl.gameIsPaused){
            return;
        }
        verifyFirstMinion();
        partyJump();
        partyFall();
    }

    private void partyFall()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            foreach (Minion minion in party)
            {
                if (minion.currentState == minion.jumpingState)
                {
                    Instantiate(fallBox, minion.transform.position, Quaternion.identity);                
                    break;
                }
            }
        }
    }

    private void partyJump()
    {
        // if (!checkJumpInput())
        // {
        //     return;
        // }
        // Debug.Log("deveria pular");
        // jumpDown = (Input.GetKey(KeyCode.Space));
        // jumpPressed = (Input.GetKeyDown(KeyCode.Space));
        if (!checkJumpInput())
        {
            return;
        }
        actuallyJump();

    }

    private void FixedUpdate()
    {

    }

    public void killMinion(Minion minion){
        if(this.party.Count == 1){
            GameManager.instance.restart();
            return;
        }
        this.party.Remove(minion);
        Destroy(minion.gameObject);
    }
    private void actuallyJump()
    {
        // if (Input.GetKeyUp(KeyCode.Space))
        // {
        //     jumpPressed = false;
        // }
        // int i = 0;
        foreach (Minion minion in party)
        {
            if (minion.currentState == minion.runningState && minion.rb.velocity.y >= 0)
            {
                // if (jumpPressed)
                // {
                // Debug.Log("Small");
                Instantiate(jumpBox, minion.transform.position, Quaternion.identity);
                AudioManager.Play(AudioManager.instance.playerJumpSound);
                // Debug.Log("Created by " + i);
                break;
                // }

                // if (jumpDown)
                // {
                //     Debug.Log("Big");
                //     Instantiate(bigJumpBox, minion.transform.position, Quaternion.identity);
                //     break;
                // }
            }

            // i++;
        }
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
    // Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonUp(0) || 
    {
        // bool input = (Input.GetKeyDown(KeyCode.Space));

        // if (Input.GetKey(KeyCode.Space))
        // {
        //     Debug.Log("Space is pressed");
        // }
        // if (!input)
        // {
        //     return false;
        // }
        // Debug.Log("Space was pressed");


        // return true;
        bool input = (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonUp(0) || Input.GetKeyDown(KeyCode.Space);
        // Debug.Log(input);
        return input;
    }
}
