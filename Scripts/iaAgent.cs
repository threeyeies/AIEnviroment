using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class iaAgent : MonoBehaviour
{
	public Transform Player;
	private NavMeshAgent naveMesh;
	private float DistanciaDePlayer, DistanciaDeAIPoint;
	public float DistanciaDePercepcion = 30, DistanciaDeSeguir = 20, DistanciaDeAtacar = 2, VelocidadDePaseo = 3, VelocidadeDePersecucion = 6, TempoPorAtaque = 1.5f, DanoDeAgent = 40;
	private bool ViendoPlayer;
	public Transform[] DestinosAleatorios;
	private int AIPointAtual;
	private bool PersiguiendoAlgo, contadorPersiguiendoAlgo, atacandoAlgo;
	private float cronometroDePersecucion, cronometroAtaque;

	void Start()
	{
		AIPointAtual = Random.Range(0, DestinosAleatorios.Length);
		naveMesh = GetComponent<NavMeshAgent>();
	}
	void Update()
	{
		DistanciaDePlayer = Vector3.Distance(Player.transform.position, transform.position);
		DistanciaDeAIPoint = Vector3.Distance(DestinosAleatorios[AIPointAtual].transform.position, transform.position);
		//============================== RAYCAST ===================================//
		RaycastHit hit;
		Vector3 deOnde = transform.position;
		Vector3 paraOnde = Player.transform.position;
		Vector3 direction = paraOnde - deOnde;
		if (Physics.Raycast(transform.position, direction, out hit, 1000) && DistanciaDePlayer < DistanciaDePercepcion)
		{
			if (hit.collider.gameObject.CompareTag("Player"))
			{
				ViendoPlayer = true;
			}
			else
			{
				ViendoPlayer = false;
			}
		}
		//================ Deciciones ================//
		if (DistanciaDePlayer > DistanciaDePercepcion)
		{
			Pasear();
		}
		if (DistanciaDePlayer <= DistanciaDePercepcion && DistanciaDePlayer > DistanciaDeSeguir)
		{
			if (ViendoPlayer == true)
			{
				Mirar();
			}
			else
			{
				Pasear();
			}
		}
		if (DistanciaDePlayer <= DistanciaDeSeguir && DistanciaDePlayer > DistanciaDeAtacar)
		{
			if (ViendoPlayer == true)
			{
				Perseguir();
				PersiguiendoAlgo = true;
			}
			else
			{
				Pasear();
			}
		}
		if (DistanciaDePlayer <= DistanciaDeAtacar)
		{
			Atacar();
		}
		//COMANDOS DE PASEAR
		if (DistanciaDeAIPoint <= 2)
		{
			AIPointAtual = Random.Range(0, DestinosAleatorios.Length);
			Pasear();
		}
		//CONTADORES DE PERSECU
		if (contadorPersiguiendoAlgo == true)
		{
			cronometroDePersecucion += Time.deltaTime;
		}
		if (cronometroDePersecucion >= 5 && ViendoPlayer == false)
		{
			contadorPersiguiendoAlgo = false;
			cronometroDePersecucion = 0;
			PersiguiendoAlgo = false;
		}
		// CONTADOR DE ATAQUE
		if (atacandoAlgo == true)
		{
			cronometroAtaque += Time.deltaTime;
		}
		if (cronometroAtaque >= TempoPorAtaque && DistanciaDePlayer <= DistanciaDeAtacar)
		{
			atacandoAlgo = true;
			cronometroAtaque = 0;
			PLAYER.VIDA = PLAYER.VIDA - DanoDeAgent;
			Debug.Log("recibio Ataque");
		}
		else if (cronometroAtaque >= TempoPorAtaque && DistanciaDePlayer > DistanciaDeAtacar)
		{
			atacandoAlgo = false;
			cronometroAtaque = 0;
			Debug.Log("error");
		}
	}
	void Pasear()
	{
		if (PersiguiendoAlgo == false)
		{
			naveMesh.acceleration = 5;
			naveMesh.speed = VelocidadDePaseo;
			naveMesh.destination = DestinosAleatorios[AIPointAtual].position;
		}
		else if (PersiguiendoAlgo == true)
		{
			contadorPersiguiendoAlgo = true;
		}
	}
	void Mirar()
	{
		naveMesh.speed = 0;
		transform.LookAt(Player);
	}
	void Perseguir()
	{
		naveMesh.acceleration = 8;
		naveMesh.speed = VelocidadeDePersecucion;
		naveMesh.destination = Player.position;
	}
	void Atacar()
	{
		atacandoAlgo = true;
	}
}