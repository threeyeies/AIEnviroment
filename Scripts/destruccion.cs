using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruccion : MonoBehaviour
{
    // Start is called before the first frame update
    /*void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("DestrucCol"))
        {
            Destroy(collision.gameObject);
        }
    }*/


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("DestrucTrig"))
        {
            Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Start()
    {


    }



}
