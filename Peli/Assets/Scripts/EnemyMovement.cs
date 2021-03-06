using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour 
{
	Transform player;
	public float speed;
	Rigidbody enemy;
	new Collider collider;
	PlayerController playerController;

	void Awake ()
	{
		playerController = GameObject.Find ("Player").GetComponent<PlayerController> ();
		collider = gameObject.GetComponent <Collider> ();
	}

	void Start()
	{
		enemy = GetComponent<Rigidbody> ();
	}

	// Vihollinen seuraa pelaajaa ellei pelaaja ole kuollut (koska silloin playerController-skripti on disabloitu)
	void Update ()
	{
		if (playerController.enabled != false) 
		{
			player = GameObject.FindWithTag ("Player").transform;
			transform.LookAt (player);
			enemy.velocity = transform.forward * speed;
		}
		// Jos pelaaja on kuollut, viholliset jatkavat matkaansa ja kulkeutuvat muiden objektien läpi
		// Jotkut viholliset jäävät kuitenkin pyörimään, mikä pitäisi korjata josain vaiheessa
		else 
		{
			enemy.velocity = transform.forward * speed;
			collider.isTrigger = true;
		}
	}
}