using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // public Minion2 minion;
    public Minion minion;
    // public CruzadeManagement cruzadeManagement;
    public PartyManager partyManager;
    public float fieldView = 100;

    //public float offset = -50f;
    // Use this for initialization

    private void Update()
    {
        // minion = cruzadeManagement.firstMinion;
        minion = partyManager.getFirstMinion();
    }
    private void LateUpdate()
    {
        if(minion == null){
            return;
        }
        //diminuir a travada da tela?
        if(transform.position.x > minion.transform.position.x){
            return;
        }
        transform.position =  new Vector3(minion.transform.position.x, transform.position.y,transform.position.z);     
    }

}