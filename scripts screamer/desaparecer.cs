using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desaparecer : MonoBehaviour
{
    GameObject llorona;
    // Start is called before the first frame update
    void Start()
    {
        llorona = GameObject.Find("screamer");
        //Debug.Log("Lllorona");
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(llorona, 0.5f);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
