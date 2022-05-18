using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration: MonoBehaviour
{
    public static WorldGeneration instance;
    public List<GameObject> worlds = new List<GameObject>();

    public GameObject worldGrid;

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
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
