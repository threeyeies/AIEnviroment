using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class susto : MonoBehaviour
{
    public GameObject flame;
    //public GameObject ghost;

    // Start is called before the first frame update
    void Start()
    {
        flame.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        flame.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        flame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
