using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int minionsToDestroyThis;
    public int minionsColliding;
    // Start is called before the first frame update
    private void Update()
    {
        if (minionsColliding == minionsToDestroyThis)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            minionsColliding++;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            minionsColliding--;
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {

    }
}
