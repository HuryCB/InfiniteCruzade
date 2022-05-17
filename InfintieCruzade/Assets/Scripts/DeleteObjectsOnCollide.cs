using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObjectsOnCollide : MonoBehaviour
{
    public Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            PartyManager.instance.killMinion(other.gameObject.GetComponent<Minion>());
            // Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("fallBox")){
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("jumpBox")){
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("collectable")){
            Destroy(other.gameObject);
        }
        // if(other.gameObject.CompareTag("flag")){
        //     Debug.Log("Colidiu");
        //     Vector3 pos = new Vector3(0f, transform.position.y, transform.position.z);
        //     Instantiate(WorldGeneration.worlds[0], pos, Quaternion.identity);
        // }
    }

    // private void OnCollisionEnter2D(Collision2D col){
    //     if(col.gameObject.CompareTag("flag")){
    //         Debug.Log("Colidiu");
    //         Vector3 pos = new Vector3(0f, transform.position.y, transform.position.z);
    //         Instantiate(WorldGeneration.worlds[0], pos, Quaternion.identity);
    //     }
    // }
}
