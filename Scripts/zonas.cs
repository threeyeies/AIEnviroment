using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zonas : MonoBehaviour
{
    public GameObject[] zonesExplorables;
    public float velocidadCaminar = 1f;
    public int zoneSeleccione = 0;
    public enum tipoMovimientos { loop, inversa, random };
    public tipoMovimientos tipoMovimiento;
    public bool fuegoEsPeligroso = false;
    



    // Start is called before the first frame update
    void Start()
    {
       
    }

    void Caminar()
    {
        if (zoneSeleccione != null) 
        {
            transform.LookAt(zonesExplorables[zoneSeleccione].transform.position);
            transform.position = Vector3.MoveTowards(transform.position, zonesExplorables[zoneSeleccione].transform.position, Time.deltaTime * velocidadCaminar);
            //agent.destination = zonesExplorables[zoneSeleccione].transform.position;
            if (getDistance(zonesExplorables[zoneSeleccione]) < 0.5f)
            {
                if(zonesExplorables[zoneSeleccione].name == "fire")
                {
                    print("Toque el fuego, sugoi");
                    //PlayerPrefs.SentInt("Fuego", 1);
                    fuegoEsPeligroso = true;
                    print("Ahora se que el fuego quema");
                }
                elegirNuevaZona();
                print("Voy pa' zona segura");
            }
        }
    }

    float getDistance(GameObject obj)
    {
        return Vector3.Distance(transform.position, obj.transform.position);
        //return Vector3.Distance(transform.position, zonesExprorables[zoneSeleccione].transform.position);
    }

    void elegirNuevaZona()
    {
        if (tipoMovimiento == tipoMovimientos.loop) 
        {
            zoneSeleccione = zoneSeleccione + 1;
            if (zoneSeleccione >= zonesExplorables.Length)
            {
                zoneSeleccione = 0;
            }
        }
        else if (tipoMovimiento == tipoMovimientos.inversa) 
        {
            zoneSeleccione = zoneSeleccione - 1;
            if (zoneSeleccione < 0)
            {
                zoneSeleccione = zonesExplorables.Length -1;
            }
        }
        else
        {
            zoneSeleccione = Random.Range(0, zonesExplorables.Length);
        }
        if(zoneSeleccione == 4 && fuegoEsPeligroso)
        {
            print("Yo no voy a ir hacia el fuego, baka");
            elegirNuevaZona();
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        Caminar();
    }
}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zonas : MonoBehaviour
{

    public GameObject[] zonesExplorables;
    public float velocidadCaminar = 1f;
    public int zoneSelecione = 0;
    public enum tipoMovimiento { loop, inversa, random };
    public tipoMovimiento tipoMovimientos;
    UnityEngine.AI.NavMeshAgent agent;

    bool fuegoEsPeligroso = false;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>(); //Conocimiento inicial
    }

    void Caminar()
    {
        if (zoneSelecione != null)
        {
            //transform.LookAt(zonesExplorables[zoneSelecione].transform.position);
            //agent.destination = Vector3.MoveTowards(transform.position, zonesExplorables[zoneSelecione].transform.position, Time.deltaTime * velocidadCaminar);
            agent.destination = zonesExplorables[zoneSelecione].transform.position;
            if (getDistance(zonesExplorables[zoneSelecione]) < 0.5f)
            {
                if (zonesExplorables[zoneSelecione].name == "fuego")
                {
                    print("ahhhh me quemo la ptm");
                    fuegoEsPeligroso = true;
                    print("El fuego quema");
                }
                elegirNuevaZona();
                print("Ya llegue we ahhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");

            }
        }
    }

    float getDistance(GameObject obj)
    {
        return Vector3.Distance(transform.position, obj.transform.position);
        //return Vector3.Distance(transform.position, zonesExplorables[zoneSelecione].transform.position); 
    }

    void elegirNuevaZona()
    {
        if (tipoMovimientos == tipoMovimiento.random)
        {
            zoneSelecione = Random.Range(0, zonesExplorables.Length);
        }
        else if (tipoMovimientos == tipoMovimiento.loop)
        {
            zoneSelecione = zoneSelecione + 1;
            if (zoneSelecione >= zonesExplorables.Length)
            {
                zoneSelecione = 0;
            }
        }
        else if (tipoMovimientos == tipoMovimiento.inversa)
        {
            zoneSelecione = zoneSelecione - 1;
            if (zoneSelecione < 0)
            {
                zoneSelecione = zonesExplorables.Length - 1;
            }
        }
        if (zoneSelecione == 4 && fuegoEsPeligroso)
        {
            print("ahhhh ahi no que me quemo la ptm");
            elegirNuevaZona();
        }
    }



    // Update is called once per frame
    void Update()
    {
        Caminar();
    }

}
*/