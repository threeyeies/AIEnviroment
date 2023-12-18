using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject nagent;
    public GameObject goalObject;

    
    void Start()
    {
        Invoke("SpawnAgent", 2);
    }

    // Update is called once per frame
    void SpawnAgent()
    {
        GameObject na = (GameObject)Instantiate(nagent, this.transform.position, Quaternion.identity);
        //na.GetComponent<walkTo>().goal = goal.Object.transform();
        Invoke("SpawnAgent", Random.Range(2, 5));
    }
}
