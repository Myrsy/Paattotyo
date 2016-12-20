using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour 
{
	public float minExplosionDamage, maxExplosionDamage;
	public float minDamageRadius, maxDamageRadius;
	public float radius;
	public float forceRadius;
	public float power;
	GameObject player;
	public GameObject explosionEffect;
	EnemyHealth enemyHealth;
	Rigidbody rigidBody;


	void Awake ()
	{
		player = GameObject.Find ("Player");
	}
	// Pelaajalla on 4 sekuntia aikaa ennen kuin räjähde katoaa
	void Start ()
	{
		Destroy (gameObject, 4f);
	}

	// Jos pelaaja koskee räjähdettä, se räjähtää
	void OnTriggerEnter (Collider other)
	{
		if (other == player.GetComponent <Collider>()) 
		{
			Destroy (gameObject);
			Explode ();
		} 
		else
			return;
	}

	// Räjähdyksessä syntyy räjähdysefekti ja viholliset ottavat damagea riippuen siitä, kuinka kaukana ne ovat räjähdystä
	void Explode ()
	{
		Instantiate (explosionEffect, transform.position, Quaternion.LookRotation(Vector3.up));
		Collider[] colliders = Physics.OverlapSphere (transform.position, radius);
		foreach (Collider collider in colliders) 
		{
			if (collider && collider.tag == "Enemy") 
			{
				float distance = Vector3.Distance (collider.transform.position, transform.position);
				enemyHealth = collider.GetComponent <EnemyHealth> ();
				rigidBody = collider.GetComponent <Rigidbody> ();
				if (enemyHealth != null && rigidBody != null) 
				{
					rigidBody.AddExplosionForce (power, transform.position, forceRadius);
					if (distance <= maxDamageRadius) 
					{
						enemyHealth.EnemyTakeDamage (maxExplosionDamage);
					} 
					else 
					{
						enemyHealth.EnemyTakeDamage (minExplosionDamage);
					}
				}
			}
		}
	}
}
